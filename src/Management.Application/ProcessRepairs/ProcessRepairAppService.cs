using Management;
using Managerment.Customers;
using Managerment.Enums;
using Managerment.ProductProcessRepairs;
using Managerment.ProductRepairs;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.ProcessRepairs
{
    [RemoteService(IsEnabled = false)]
    public class ProcessRepairAppService : ManagementAppService, IProcessRepairAppService
    {
        private readonly IProcessRepairRepository _processRepairRepository;
        private readonly ProcessRepairManager _processRepairManager;
        private readonly IProductRepairRepository _productRepairRepository;
        private readonly ICustomerRepository _customerRepository;

        public ProcessRepairAppService(
            IProcessRepairRepository processRepairRepository,
            ProcessRepairManager processRepairManager,
            IProductRepairRepository productRepairRepository,
            ICustomerRepository customerRepository)
        {
            _processRepairRepository = processRepairRepository;
            _processRepairManager = processRepairManager;
            _productRepairRepository = productRepairRepository;
            _customerRepository = customerRepository;
        }
        public async Task CreateAsync(CreateProcessRepairDto input)
        {
            try
            {

                var process_repair = _processRepairManager.CreateAsync(input.PR_date_order, input.PR_status_fix, input.PR_process_repair, input.Id_order_repair);

                await _processRepairRepository.InsertAsync(process_repair);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task<ProcessRepairDetailDto> GetProcessRepairDetail (Guid process_repair_id, Guid product_repair_id, Guid customer_id)         
        {
            var product_detail = await _productRepairRepository.GetAsync(product_repair_id);
            var process_repair = await _processRepairRepository.GetAsync(process_repair_id);
            var customer_detail = await _customerRepository.GetAsync(customer_id);
            ProcessRepairDetailDto processRepairDetailDto = new()
            {
                Phone = customer_detail.C_phone,
                PR_name = product_detail.PR_name,
                Product_repair_type_name = EnumAppService.GetNameEnum<EProductRepairTypeEnum>(product_detail.Product_repair_type),
                Status_error = product_detail.PR_status_error,
                Receipt_date = product_detail.CreationTime,
                PR_date_order = process_repair.PR_date_order,
                PR_price = product_detail.PR_price,
                Date_finish = product_detail.PR_date_finish,
                Process_repair_type_name = EnumAppService.GetNameEnum<EProcessRepairType>(process_repair.PR_process_repair)

            };
            return processRepairDetailDto;
        }
        public async Task DeleteAsync(Guid id)
        {
            await _processRepairRepository.DeleteAsync(id);
        }

        public async Task UpdateNewPrice(Guid product_repair_id, Guid process_repair_id, decimal input)
        {
            //chỉnh sửa giá
            var product_repair = await _productRepairRepository.GetAsync(product_repair_id);

            product_repair.PR_price = input;

            await _productRepairRepository.UpdateAsync(product_repair);

            //update lại ngày báo giá

            var process_repair = await _processRepairRepository.GetAsync(process_repair_id);
            process_repair.PR_date_order = DateTime.Now;
            await _processRepairRepository.UpdateAsync(process_repair);

        }
    }
}
