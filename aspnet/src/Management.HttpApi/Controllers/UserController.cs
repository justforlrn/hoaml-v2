using Managerment.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/user")]
    public class UserController : ManagermentController
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost]
        public async Task<UserDto> CreateAsync([FromBody] CreateUserDto input)
        {
            var user = await _userAppService.CreateAsync(input);

            return user;
        }
        [HttpGet("users")]
        public async Task<List<UserDto>> GetListAsync()
        {
            return await _userAppService.GetListAsync();
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] UpdateUserDto input)
        {
            await _userAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _userAppService.DeleteAsync(id);
        }
    }
}
