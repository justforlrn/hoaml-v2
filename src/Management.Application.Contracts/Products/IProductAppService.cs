using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> GetAsync(Guid id);

        Task<ResultPageProductDto> GetListAsync(int page, int perPage, string filter, Guid idCategory, Guid idProductCondition,Guid idProductUnit, Guid idManuFacturer);

        Task<ProductDto> CreateAsync(CreateUpdateProductDto input);

        Task UpdateAsync(Guid id, CreateUpdateProductDto input);

        Task DeleteAsync(Guid id);
    }
}
