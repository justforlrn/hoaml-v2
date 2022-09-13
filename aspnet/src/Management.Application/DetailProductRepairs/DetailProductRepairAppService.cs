using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.DetailProductRepairs
{
    [RemoteService(IsEnabled = false)]
    public class DetailProductRepairAppService : ManagementAppService, IDetailProductRepairAppService
    {
        private readonly IDetailProductRepairRepository _detailProductRepairRepository;
        private readonly DetailProductRepairManager _detailProductRepairManager;

        public DetailProductRepairAppService(
            IDetailProductRepairRepository detailProductRepairRepository,
            DetailProductRepairManager detailProductRepairManager)
        {
            _detailProductRepairRepository = detailProductRepairRepository;
            _detailProductRepairManager = detailProductRepairManager;
        }
        public async Task<DetailProductRepairDto> CreateAsync(CreateDetailProductRepairDto input)
        {
            var detailProductRepair = _detailProductRepairManager.CreateAsync(input.PD_CPU, input.PD_HDD, input.PD_Ram, input.PD_Wifi, input.PD_Pin, input.PD_Adapter,
                                         input.PD_Keyboard, input.PD_PSU, input.PD_LCD, input.Text);

            await _detailProductRepairRepository.InsertAsync(detailProductRepair);

            return ObjectMapper.Map<DetailProductRepair, DetailProductRepairDto>(detailProductRepair);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _detailProductRepairRepository.DeleteAsync(id);
        }

        public async Task<List<DetailProductRepairDto>> GetListAsync()
        {
            var detailProductRepairs = await _detailProductRepairRepository.GetListAsync();

            return ObjectMapper.Map<List<DetailProductRepair>, List<DetailProductRepairDto>>(detailProductRepairs);
        }
    }
}
