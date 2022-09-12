using Managerment.CustomerTypes;
using Managerment.ProcessRepairs;
using Managerment.ProductProcessRepairs;
using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.OrderRepairs
{
    public interface IOrderRepairAppService : IApplicationService
    {
        Task<OrderRepairDetail> GetAsync(Guid id);

        Task<ReponseListDataDto<OrderRepairListDto>> GetListAsync(int page, int perPage, string filter, DateTime? fromDate, DateTime? toDate, 
            ECustomerTypeEnum? customerTypeEnum);

        Task<ReponseDataDto<ListProcessRepairDto>> GetListProcessRepair(int page, int perPage, string filter = null, DateTime? fromDate = null,
                         DateTime? toDate = null, ECustomerTypeEnum? customerTypeEnum = null, EProcessRepairType? eProcessRepairType = null, Guid? user_id = null);
        Task<OrderRepairDto> CreateAsync(CreateOrderRepairDto input);

        Task UpdateAsync(Guid id, CreateUpdateOrderRepairDto input);

        Task DeleteAsync(Guid id);

        Task UpdateProcessRepair(Guid process_repair_id, Guid product_repair_id, Guid order_repair_id, UpdateProcessProductRepairDto updateProcessProductRepairDto);
    }
}
