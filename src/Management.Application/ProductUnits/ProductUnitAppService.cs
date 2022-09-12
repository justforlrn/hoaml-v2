using Management;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.ProductUnits
{
    [RemoteService(IsEnabled = false)]
    public class ProductUnitAppService : ManagementAppService, IProductUnitAppService
    {
        private readonly IProductUnitRepository _productUnitRepository;
        private readonly ProductUnitManager _productUnitManager;

        public ProductUnitAppService(
            IProductUnitRepository productUnitRepository,
            ProductUnitManager productUnitManager)
        {
            _productUnitRepository = productUnitRepository;
            _productUnitManager = productUnitManager;
        }

        public async Task<ProductUnitDto> CreateAsync(CreateUpdateProductUnitDto input)
        {
            if (await _productUnitRepository.AnyAsync(x => x.Unit_name == input.Unit_name))
            {
                throw new UserFriendlyException("Tên đã tồn tại !! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {
                    var unit = _productUnitManager.CreateAsync(input.Unit_name);

                    await _productUnitRepository.InsertAsync(unit);

                    return ObjectMapper.Map<ProductUnit, ProductUnitDto>(unit);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productUnitRepository.DeleteAsync(id);
        }

        public async Task<ProductUnitDto> GetAsync(Guid id)
        {
            var productUnit = await _productUnitRepository.GetAsync(id);
            return ObjectMapper.Map<ProductUnit, ProductUnitDto>(productUnit);
        }

        public async Task<PagedResultDto<ProductUnitDto>> GetListAsync(int page, int perPage, string filter)
        {
            var productUnits = await _productUnitRepository.GetListAsync(page, perPage, filter);
            var totalCount = filter == null
                ? await _productUnitRepository.CountAsync()
                : await _productUnitRepository.CountAsync(
                    sup => sup.Unit_name.ToLower().Trim().Contains(filter.ToLower().Trim()));

            return new PagedResultDto<ProductUnitDto>(
                totalCount,
                ObjectMapper.Map<List<ProductUnit>, List<ProductUnitDto>>(productUnits)
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductUnitDto input)
        {
            var unit = await _productUnitRepository.GetAsync(id);

            unit.Unit_name = input.Unit_name;

            await _productUnitRepository.UpdateAsync(unit);
        }
    }
}
