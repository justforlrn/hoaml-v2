using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Roles
{
    [RemoteService(IsEnabled = false)]
    public class RoleAppService : ManagementAppService, IRoleApppService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager _roleManager;

        public RoleAppService(
            IRoleRepository roleRepository,
            RoleManager roleManager)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }
        public async Task<RoleDto> CreateAsync(CreateUpdateRoleDto input)
        {
            if (await _roleRepository.AnyAsync(x => x.Roles_name == input.Roles_name))
            {
                throw new UserFriendlyException("Đã tồn tại nhóm người dùng");
            }
            else
            {
                try
                {

                    var role = _roleManager.CreateAsync(input.Roles_name, input.Permission);

                    await _roleRepository.InsertAsync(role);

                    return ObjectMapper.Map<Role, RoleDto>(role);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _roleRepository.DeleteAsync(id);
        }

        public async Task<List<RoleDto>> GetListAsync()
        {
            var roles = await _roleRepository.GetListAsync();
            return ObjectMapper.Map<List<Role>, List<RoleDto>>(roles);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateRoleDto input)
        {
            var role = await _roleRepository.GetAsync(id);

            role.Roles_name = input.Roles_name;
            role.Permission = input.Permission;

            await _roleRepository.UpdateAsync(role);
        }
    }
}
