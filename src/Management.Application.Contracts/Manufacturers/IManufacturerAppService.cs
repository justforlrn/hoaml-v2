using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.Manufacturers
{
    public interface IManufacturerAppService : IApplicationService
    {
        Task<ManufacturerDto> GetAsync(Guid id);

        Task<PagedResultDto<ManufacturerDto>> GetListAsync(int skip, int take, string filter);

        Task<ManufacturerDto> CreateAsync(CreateUpdateManufacturerDto input);

        Task UpdateAsync(Guid id, CreateUpdateManufacturerDto input);

        Task DeleteAsync(Guid id);
    }
}
