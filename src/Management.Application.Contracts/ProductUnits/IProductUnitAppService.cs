using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.ProductUnits
{
    public interface IProductUnitAppService : IApplicationService
    {
        Task<ProductUnitDto> GetAsync(Guid id);

        Task<PagedResultDto<ProductUnitDto>> GetListAsync(int skip, int take, string filter);

        Task<ProductUnitDto> CreateAsync(CreateUpdateProductUnitDto input);

        Task UpdateAsync(Guid id, CreateUpdateProductUnitDto input);

        Task DeleteAsync(Guid id);
    }
}
