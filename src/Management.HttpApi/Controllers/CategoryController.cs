using Managerment.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ManagermentController
    {
        private readonly CategoryAppService _categoryAppService;
        public CategoryController(CategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        /// <summary>
        /// Tạo danh mục
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CategoryDto> CreateAsync([FromBody] CreateUpdateCategoryDto input)
        {
            var category = await _categoryAppService.CreateAsync(input);

            return category;
        }

        [HttpGet("category/{id}")]
        public async Task<CategoryDto> GetAsync(Guid id)
        {
            return await _categoryAppService.GetAsync(id);
        }

        /// <summary>
        /// Danh sách danh mục
        /// </summary>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        [HttpGet("categories")]
        public async Task<List<ListCategoryDto>> GetListAsync(Guid? parent_id)
        {
            return await _categoryAppService.GetListAsync(parent_id);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateCategoryDto input)
        {
            await _categoryAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _categoryAppService.DeleteAsync(id);
        }
    }
}
