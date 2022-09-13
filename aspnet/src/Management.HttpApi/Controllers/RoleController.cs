using Managerment.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/role")]
    public class RoleController : ManagermentController
    {
        private readonly IRoleApppService _roleAppService;
        public RoleController(IRoleApppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        [HttpPost]
        public async Task<RoleDto> CreateAsync([FromBody] CreateUpdateRoleDto input)
        {
            var role = await _roleAppService.CreateAsync(input);

            return role;
        }
        [HttpGet("suppliers")]
        public async Task<List<RoleDto>> GetListAsync()
        {
            return await _roleAppService.GetListAsync();
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateRoleDto input)
        {
            await _roleAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _roleAppService.DeleteAsync(id);
        }
    }
}
