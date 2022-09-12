using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.Stores
{
    public interface IStoreAppService : IApplicationService
    {
        Task<StoreDto> GetAsync(Guid id);

        Task<List<StoreDto>> GetListAsync();

        Task<StoreDto> CreateAsync(CreateUpdateStoreDto input);

        Task UpdateAsync(Guid id, CreateUpdateStoreDto input);

        Task DeleteAsync(Guid id);
    }
}
