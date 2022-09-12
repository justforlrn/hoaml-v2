using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.DetailProductRepairs
{
    public interface IDetailProductRepairAppService : IApplicationService
    {
        Task<List<DetailProductRepairDto>> GetListAsync();

        Task<DetailProductRepairDto> CreateAsync(CreateDetailProductRepairDto input);

        Task DeleteAsync(Guid id);
    }
}
