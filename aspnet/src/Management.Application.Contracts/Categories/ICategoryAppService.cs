using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<CategoryDto> GetAsync(Guid id);

        Task<List<ListCategoryDto>> GetListAsync(Guid? parent_id);

        Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input);

        Task UpdateAsync(Guid id, CreateUpdateCategoryDto input);

        Task DeleteAsync(Guid id);
    }
}
