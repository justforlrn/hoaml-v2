using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Manufacturers
{
    [RemoteService(IsEnabled = false)]
    public class ManufacturerAppService : ManagementAppService, IManufacturerAppService
    {
        private readonly IManuFacturerRepository _manufacturerRepository;
        private readonly ManufacturerManager _manufacturerManager;

        public ManufacturerAppService(
            IManuFacturerRepository manuFacturerRepository,
            ManufacturerManager manufacturerManager)
        {
            _manufacturerRepository = manuFacturerRepository;
            _manufacturerManager = manufacturerManager;
        }
        public async Task<ManufacturerDto> CreateAsync(CreateUpdateManufacturerDto input)
        {
            if (await _manufacturerRepository.AnyAsync(x => x.Name == input.Name))
            {
                throw new UserFriendlyException("Tên đã tồn tại !! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {
                    var manu = _manufacturerManager.CreateAsync(input.Name);

                    await _manufacturerRepository.InsertAsync(manu);

                    return ObjectMapper.Map<Manufacturer, ManufacturerDto>(manu);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _manufacturerRepository.DeleteAsync(id);
        }

        public async Task<ManufacturerDto> GetAsync(Guid id)
        {
            var product = await _manufacturerRepository.GetAsync(id);
            return ObjectMapper.Map<Manufacturer, ManufacturerDto>(product);
        }

        public async Task<PagedResultDto<ManufacturerDto>> GetListAsync(int page, int perPage, string filter)
        {
            var manufacturers = await _manufacturerRepository.GetListAsync(page, perPage, filter);
            var totalCount = filter == null
                ? await _manufacturerRepository.CountAsync()
                : await _manufacturerRepository.CountAsync(
                    manu => manu.Name.ToLower().Trim().Contains(filter.ToLower().Trim()));

            return new PagedResultDto<ManufacturerDto>(
                totalCount,
                ObjectMapper.Map<List<Manufacturer>, List<ManufacturerDto>>(manufacturers)
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateManufacturerDto input)
        {
            var manufacturer = await _manufacturerRepository.GetAsync(id);

            manufacturer.Name = input.Name;

            await _manufacturerRepository.UpdateAsync(manufacturer);
        }
    }
}
