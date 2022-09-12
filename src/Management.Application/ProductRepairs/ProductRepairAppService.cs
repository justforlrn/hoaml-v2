using Management;
using Managerment.CustomCodes;
using Managerment.DetailProductRepairs;
using Managerment.OrderRepairs;
using Managerment.ProcessRepairs;
using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.ProductRepairs
{
    [RemoteService(IsEnabled = false)]
    public class ProductRepairAppService : ManagementAppService, IProductRepairAppService
    {
        private readonly IProductRepairRepository _productRepairRepository;
        private readonly ProductRepairManager _productRepairManager;
        private readonly CustomCodeAppService _customCodeAppService;
        private readonly IDetailProductRepairAppService _detailProductRepairAppService;
        private readonly OrderRepairAppService _orderRepairAppService;
        private readonly IProcessRepairAppService _processRepairAppService;

        public ProductRepairAppService(
            IProductRepairRepository productRepairRepository,
            ProductRepairManager productRepairManager,
            OrderRepairAppService orderRepairAppService,
            IDetailProductRepairAppService detailProductRepairAppService,
            CustomCodeAppService customCodeAppService,
            IProcessRepairAppService processRepairAppService)
        {
            _productRepairRepository = productRepairRepository;
            _productRepairManager = productRepairManager;
            _orderRepairAppService = orderRepairAppService;
            _detailProductRepairAppService = detailProductRepairAppService;
            _customCodeAppService = customCodeAppService;
            _processRepairAppService = processRepairAppService;
        }
        public async Task CreateAsync(CreateUpdateOrderRepairDto input)
        {
            //if (input.PR_repair_type)
            //{
            //    throw new BusinessException("Xin vui lòng chọn 1 sản phẩm ! Cảm ơn");
            //}


            //order_repair code
            var productCode = await _customCodeAppService.GenerateCode("BN");
            //tạo order repair 
            CreateOrderRepairDto createOrderRepairDto = new()
            {
                ID_cus = input.Id_customer,
                ID_user = input.Id_user,
                OR_code = productCode,
                Notes = input.Notes
            };
            var order_repair = await _orderRepairAppService.CreateAsync(createOrderRepairDto);

            await _customCodeAppService.UpdateAsync("BN");
            //sau khi tạo xong order_repair tạo process_repair
            CreateProcessRepairDto createProcessRepairDto = new()
            {
                Id_order_repair = order_repair.Id,
                PR_date_order = DateTime.Now,
                PR_process_repair = EProcessRepairType.Checking,
                PR_status_fix = null
            };

            await _processRepairAppService.CreateAsync(createProcessRepairDto);

            //từ id order_repair tạo những sản phẩm repair
            foreach (var productDto in input.Product_repair)
            {
                // tạo product detail order repair
                var detail_product_repair = ObjectMapper.Map<DetailProductRepairCreateOrderDetailDto, CreateDetailProductRepairDto>(productDto.Detail_product_pepairs);

                var detail = await _detailProductRepairAppService.CreateAsync(detail_product_repair);

                // tạo product prepair
                DateTime pr_quote = DateTime.MinValue; 

                if(productDto.PR_price > 0)
                {
                    pr_quote = productDto.PR_quote_date;
                }    

                var pr_repair = _productRepairManager.CreateAsync(productDto.PR_code, productDto.PR_Name, productDto.PR_date_finish, pr_quote
                    , productDto.PR_status_error,productDto.PR_price, productDto.PR_repair_type, order_repair.Id, detail.Id);

                await _productRepairRepository.InsertAsync(pr_repair);
            }    
          
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public  Task<ProductRepairDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductRepairDto> GetListAsync(string filter)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductRepairDto input)
        {
            throw new NotImplementedException();
        }
    }
}
