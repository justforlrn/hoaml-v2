using Managerment.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.Suppliers
{
    public interface ISupplierAppService : IApplicationService
    {
        Task<SupplierDto> GetAsync(Guid id);

        Task<PagedResultDto<SupplierDto>> GetListAsync(int skip, int take, string filter);

        Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input);

        Task UpdateAsync(Guid id, CreateUpdateSupplierDto input);

        Task DeleteAsync(Guid id);
    }
}
