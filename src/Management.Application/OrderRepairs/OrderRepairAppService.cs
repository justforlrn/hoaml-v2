using Management;
using Managerment.CustomCodes;
using Managerment.Customers;
using Managerment.CustomerTypes;
using Managerment.DetailProductRepairs;
using Managerment.Enums;
using Managerment.ProcessRepairs;
using Managerment.ProductProcessRepairs;
using Managerment.ProductRepairs;
using Managerment.ProductRepairTypes;
using Managerment.Shares;
using Managerment.Stores;
using Managerment.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Managerment.OrderRepairs
{
    [RemoteService(IsEnabled = false)]
    public class OrderRepairAppService : ManagementAppService, IOrderRepairAppService
    {

        private readonly IOrderRepairRepository _orderRepairRepository;
        private readonly OrderRepairManager _orderRepairManager;
        private readonly ICustomerRepository _customerRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepairRepository _productRepairRepository;
        private readonly IDetailProductRepairRepository _detailProductRepairRepository;
        private readonly IProcessRepairRepository _processRepairRepository;
        private readonly IProcessRepairAppService _processRepairAppService;
        public OrderRepairAppService(
            IOrderRepairRepository orderRepairRepository,
            OrderRepairManager orderRepairManager,
            ICustomerRepository customerRepository,
            IStoreRepository storeRepository,
            IUserRepository userRepository,
            IProductRepairRepository productRepairRepository,
            IDetailProductRepairRepository detailProductRepairRepository,
            IProcessRepairRepository processRepairRepository,
            IProcessRepairAppService processRepairAppService
            )
        {
            _orderRepairRepository = orderRepairRepository;
            _orderRepairManager = orderRepairManager;
            _customerRepository = customerRepository;
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _productRepairRepository = productRepairRepository;
            _detailProductRepairRepository = detailProductRepairRepository;
            _processRepairRepository = processRepairRepository;
            _processRepairAppService = processRepairAppService;
        }
        public async Task<OrderRepairDto> CreateAsync(CreateOrderRepairDto input)
        {
            try
            {
                var order_repair = _orderRepairManager.CreateAsync(input.OR_code, input.Notes, input.ID_cus, input.ID_user);

                await _orderRepairRepository.InsertAsync(order_repair);

                return ObjectMapper.Map<OrderRepair, OrderRepairDto>(order_repair);
            }
            catch(Exception ex)
            {
                throw new BusinessException("Có lỗi xảy ra "+ ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _productRepairRepository.DeleteAsync(x => x.ID_order_repair == id);
                await _orderRepairRepository.DeleteAsync(id);
            }
            catch
            {
                throw new BusinessException("Có lỗi xảy ra");
            }

        }

        public async Task<OrderRepairDetail> GetAsync(Guid id)
        {
            var order_repair = await _orderRepairRepository.GetAsync(id);

            var product_repair = await _productRepairRepository.GetListAsync(x => x.ID_order_repair == id);

            OrderRepairDetail result = new();

            result.Customer_name = _customerRepository.SingleOrDefaultAsync(x => x.Id == order_repair.ID_cus).Result.C_name;
            result.Notes = order_repair.Notes;
            result.Product_repair = ObjectMapper.Map<List<ProductRepair>, List<DetailListProductRepairDto>>(product_repair);

            foreach(var item in result.Product_repair)
            {
                var order_detail_product =await _detailProductRepairRepository.GetAsync(x => x.Id == item.ID_detail);

                item.PR_repair_type_name = EnumAppService.GetNameEnum<EProductRepairTypeEnum>(item.PR_repair_type);

                item.Detail_product_repair = ObjectMapper.Map<DetailProductRepair, DetailProductRepairDto>(order_detail_product);
            }    

            return result;
        }

        public async Task<ReponseListDataDto<OrderRepairListDto>> GetListAsync(int page, int perPage, string filter,DateTime? fromDate, DateTime? toDate, ECustomerTypeEnum? customerTypeEnum)
        {
            var list_order_repair = await _orderRepairRepository.GetListAsync(page, perPage, filter, fromDate, toDate, customerTypeEnum);
            List<OrderRepairListDto> result = new();
            foreach(var item in list_order_repair.Item2)
            {
                var customer = await _customerRepository.SingleOrDefaultAsync(x => x.Id == item.ID_cus);
                var user = await _userRepository.SingleOrDefaultAsync(x=>x.Id == item.ID_user);
                var store = await _storeRepository.SingleOrDefaultAsync(x => x.Id == user.Id_store);
                OrderRepairListDto orderRepairListDto = new()
                {
                    Id = item.Id,
                    Order_repair_code = item.OR_code,
                    CreationTime = item.CreationTime,
                    Customer_type = EnumAppService.GetNameEnum<ECustomerTypeEnum>(customer.Customer_type),
                    Cus_name = customer.C_name,
                    Cus_phone = customer.C_phone,
                    Store_name = store.Store_name,
                    User_name = user.U_name,
                    Amount = 1 
                };
                result.Add(orderRepairListDto);
            }
            int pageCout = list_order_repair.Item1 == 0 ? 0 : list_order_repair.Item1 / perPage + 1;

            return new ReponseListDataDto<OrderRepairListDto>()
            {
                Count = list_order_repair.Item1,
                Page = page,
                Per_page = perPage,
                Total_pages = pageCout,
                Data = result
            };
        }

        public async Task UpdateAsync(Guid id, CreateUpdateOrderRepairDto input)
        {
            //chỉnh sửa order_detail
            var order_repair = await _orderRepairRepository.GetAsync(id);

            order_repair.Notes = input.Notes;
            order_repair.ID_cus = input.Id_customer;
            order_repair.ID_user = input.Id_user;

            var list_product_repair = await _productRepairRepository.GetListAsync(x => x.ID_order_repair == id);
            foreach(var item in list_product_repair)
            {
                //sửa detail product repair
                var product_repair_detail =await _detailProductRepairRepository.GetAsync(x => x.Id == item.ID_detail);
                foreach (var dto in input.Product_repair)
                {
                    ///pr code
                    item.PR_code = dto.PR_code;
                    item.PR_price = dto.PR_price;
                    item.Product_repair_type = dto.PR_repair_type;
                    item.PR_status_error = dto.PR_status_error;
                    item.PR_price = dto.PR_price;
                    item.PR_date_finish = dto.PR_date_finish;

                    ///detail product 
                    product_repair_detail = ObjectMapper.Map<DetailProductRepairCreateOrderDetailDto, DetailProductRepair>(dto.Detail_product_pepairs);
                }
                await _detailProductRepairRepository.UpdateAsync(product_repair_detail);
            }
            //update product repair
            await _productRepairRepository.UpdateManyAsync(list_product_repair);
        }

        // lấy danh sách quy trình sửa chữa
        /// <summary>
        /// danh sánh quy trình sửa chữa
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="customerTypeEnum"></param>
        /// <returns></returns>
        public async Task<ReponseDataDto<ListProcessRepairDto>> GetListProcessRepair(int page, int perPage, string filter = null, DateTime? fromDate = null,
                                 DateTime? toDate = null, ECustomerTypeEnum? customerTypeEnum = null, EProcessRepairType? eProcessRepairType = null, Guid? user_id = null)
        {
            var order_repair = await _orderRepairRepository.GetQueryableAsync();
            var customer_join = await _customerRepository.GetQueryableAsync();
            var user_join = await _userRepository.GetQueryableAsync();
            var process_repair_join = await _processRepairRepository.GetQueryableAsync();
            var product_repair_join = await _productRepairRepository.GetQueryableAsync();

            var query = from orderRepair in order_repair
                        join customer in customer_join on orderRepair.ID_cus equals customer.Id
                        join user in user_join on orderRepair.ID_user equals user.Id
                        join process_repair in process_repair_join on orderRepair.Id equals process_repair.Id_order_repair
                        join product_repair in product_repair_join on orderRepair.Id equals product_repair.ID_order_repair
                        where (filter == null || customer.C_name.Contains(filter) && customer.C_code.Contains(filter) && customer.C_phone.Contains(filter))
                        && fromDate == null && toDate == null || fromDate.GetValueOrDefault() <= orderRepair.CreationTime && orderRepair.CreationTime <= toDate.GetValueOrDefault()
                        && customerTypeEnum == null || customer.Customer_type == customerTypeEnum
                        && eProcessRepairType == null || process_repair.PR_process_repair == eProcessRepairType
                        && user_id == null || user.Id == user_id
                        select new DataProcessRepairDto
                        {                           
                            Id_process_repair = process_repair.Id,
                            Id_product_repair = product_repair.Id,
                            Id_order_repair = orderRepair.Id,
                            Id_customer = customer.Id,
                            Cus_name = customer.C_name,
                            Order_repair_code = orderRepair.OR_code,
                            Product_repair_code = product_repair.PR_code,
                            Model = product_repair.PR_name,
                            Process_repair_type = process_repair.PR_process_repair,
                            Process_repair_type_name = EnumAppService.GetNameEnum<EProcessRepairType>(process_repair.PR_process_repair),
                            Status_error = product_repair.PR_status_error,
                            Status_fix = process_repair.PR_status_fix,
                            Received_date = process_repair.PR_date_order,
                            Quote_date = product_repair.PR_quote_date,
                            Date_finish = product_repair.PR_date_finish,
                            Fix_price = product_repair.PR_price,
                            User_name_fix = user.U_name
                        };
            
            int pageCout = !query.Any() ? 0 : query.Count() / perPage + 1;

            ListProcessRepairDto listProcessRepairDto = new()
            {
                Checking_count = query.Count(x => x.Process_repair_type == EProcessRepairType.Checking),
                Fixing_count = query.Count(x => x.Process_repair_type == EProcessRepairType.Fixing),
                Fixed_count = query.Count(x => x.Process_repair_type == EProcessRepairType.Fixed),
                Quote_count = query.Count(x => x.Process_repair_type == EProcessRepairType.Quote),
                Return_customer = query.Count(x => x.Process_repair_type == EProcessRepairType.Return_customer),
                Data_process_repair = query.Skip((page - 1) * perPage).Take(perPage).ToList()
            };
            return new ReponseDataDto<ListProcessRepairDto>()
            {
                Count = query.Count(),
                Page = page,
                Per_page = perPage,
                Total_pages = pageCout,
                Data = listProcessRepairDto
            };
        }
        public async Task UpdateProcessRepair (Guid process_repair_id , Guid product_repair_id ,Guid order_repair_id,  UpdateProcessProductRepairDto updateProcessProductRepairDto)
        {
            //sửa date finish của product_repair
            var product_repair = await _productRepairRepository.GetAsync(product_repair_id);

            product_repair.PR_date_finish = updateProcessProductRepairDto.Date_finish;

            await _productRepairRepository.UpdateAsync(product_repair);

            //sửa process_repair 
            var process_repair = await _processRepairRepository.GetAsync(process_repair_id);

            process_repair.PR_status_fix = updateProcessProductRepairDto.Status_fix;

            process_repair.PR_process_repair = updateProcessProductRepairDto.Process_repair_type;

            await _processRepairRepository.UpdateAsync(process_repair);

            //nhân viên sửa chữa order_repair

            var order_repair = await _orderRepairRepository.GetAsync(order_repair_id);
            order_repair.ID_user = updateProcessProductRepairDto.User_id;
            await _orderRepairRepository.UpdateAsync(order_repair);
        }


    }

}
