using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.ProcessRepairs
{
    public interface IProcessRepairAppService : IApplicationService
    {
        Task CreateAsync(CreateProcessRepairDto input);
        Task<ProcessRepairDetailDto> GetProcessRepairDetail(Guid process_repair_id, Guid product_repair_id, Guid customer_id);
        Task DeleteAsync(Guid id);
        Task UpdateNewPrice(Guid product_repair_id, Guid process_repair_id, decimal input);
    }
}
