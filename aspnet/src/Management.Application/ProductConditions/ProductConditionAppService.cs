using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.ProductConditions
{
    [RemoteService(IsEnabled = false)]
    public class ProductConditionAppService : ManagementAppService, IProductConditionAppService
    {
        private readonly IProductConditionRepository _productConditionRepository;
        private readonly ProductConditionManager _productConditionManager;

        public ProductConditionAppService(
            IProductConditionRepository productConditionRepository,
            ProductConditionManager productConditionManager)
        {
            _productConditionRepository = productConditionRepository;
            _productConditionManager = productConditionManager;
        }
        public async Task<ProductConditionDto> CreateAsync(CreateUpdateProductConditionDto input)
        {
            if (await _productConditionRepository.AnyAsync(x => x.Cond_name == input.Cond_name))
            {
                throw new UserFriendlyException("Tên đã tồn tại !! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {
                    var con = _productConditionManager.CreateAsync(input.Cond_name);

                    await _productConditionRepository.InsertAsync(con);

                    return ObjectMapper.Map<ProductCondition, ProductConditionDto>(con);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productConditionRepository.DeleteAsync(id);
        }

        public async Task<ProductConditionDto> GetAsync(Guid id)
        {
            var product = await _productConditionRepository.GetAsync(id);
            return ObjectMapper.Map<ProductCondition, ProductConditionDto>(product);
        }

        public async Task<PagedResultDto<ProductConditionDto>> GetListAsync(int page, int perPage, string filter)
        {
            var productConditions = await _productConditionRepository.GetListAsync(page, perPage, filter);
            var totalCount = filter == null
                ? await _productConditionRepository.CountAsync()
                : await _productConditionRepository.CountAsync(
                    con => con.Cond_name.ToLower().Trim().Contains(filter.ToLower().Trim()));

            return new PagedResultDto<ProductConditionDto>(
                totalCount,
                ObjectMapper.Map<List<ProductCondition>, List<ProductConditionDto>>(productConditions)
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductConditionDto input)
        {
            var productCondition = await _productConditionRepository.GetAsync(id);

            productCondition.Cond_name = input.Cond_name;

            await _productConditionRepository.UpdateAsync(productCondition);
        }
    }
}
