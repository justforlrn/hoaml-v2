using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Categories
{
    [RemoteService(IsEnabled = false)]
    public class CategoryAppService : ManagementAppService, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryManager _categoryManager;

        public CategoryAppService(
            ICategoryRepository categoryRepository,
            CategoryManager categoryManager)
        {
            _categoryRepository = categoryRepository;
            _categoryManager = categoryManager;
        }

        public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            if(await _categoryRepository.AnyAsync(x=>x.Cat_name == input.Cat_name && x.Parent_Id == input.Parent_Id))
            {
                throw new UserFriendlyException("Tên cùng cấp đã tồn tại !! Hãy thử đặt tên khác");
            }    
            else
            {
                try
                {
                    var cat = _categoryManager.CreateAsync(input.Cat_name, input.Parent_Id);

                    await _categoryRepository.InsertAsync(cat);

                    return ObjectMapper.Map<Category, CategoryDto>(cat);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }    
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var product = await _categoryRepository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(product);
        }

        public async Task<List<ListCategoryDto>> GetListAsync(Guid? parent_id)
        {
            var categories = await _categoryRepository.GetListAsync(parent_id);

            var result = new List<ListCategoryDto>();

            foreach(var cat in categories)
            {
                var catsMap = ObjectMapper.Map<Category, ListCategoryDto>(cat);
                if (cat.Parent_Id == default)
                {
                    var listCategoryParent = await _categoryRepository.GetListByParentIdAsync(cat.Id);
                    catsMap.CategoryParents = ObjectMapper.Map<List<Category>, List<CategoryDto>>(listCategoryParent);
                }
                result.Add(catsMap);
            }
            return result;
        }

        public async Task UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            var cat = await _categoryRepository.GetAsync(id);

            cat.Cat_name = input.Cat_name;

            await _categoryRepository.UpdateAsync(cat);
        }
    }
}
