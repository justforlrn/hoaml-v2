using Managerment.OrderRepairs;
using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.ProductRepairs
{
    public interface IProductRepairAppService : IApplicationService
    {
        Task<ProductRepairDto> GetAsync(Guid id);

        Task<ProductRepairDto> GetListAsync(string filter);

        Task CreateAsync(CreateUpdateOrderRepairDto input);

        Task UpdateAsync(Guid id, CreateUpdateProductRepairDto input);

        Task DeleteAsync(Guid id);
    }
}
