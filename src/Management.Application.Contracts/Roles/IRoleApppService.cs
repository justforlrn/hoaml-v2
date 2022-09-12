using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.Roles
{
    public interface IRoleApppService : IApplicationService
    {
        Task<List<RoleDto>> GetListAsync();

        Task<RoleDto> CreateAsync(CreateUpdateRoleDto input);

        Task UpdateAsync(Guid id, CreateUpdateRoleDto input);

        Task DeleteAsync(Guid id);
    }
}
