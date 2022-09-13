using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.ProductConditions
{
    public interface IProductConditionAppService : IApplicationService
    {
        Task<ProductConditionDto> GetAsync(Guid id);

        Task<PagedResultDto<ProductConditionDto>> GetListAsync(int skip, int take, string filter);

        Task<ProductConditionDto> CreateAsync(CreateUpdateProductConditionDto input);

        Task UpdateAsync(Guid id, CreateUpdateProductConditionDto input);

        Task DeleteAsync(Guid id);
    }
}
