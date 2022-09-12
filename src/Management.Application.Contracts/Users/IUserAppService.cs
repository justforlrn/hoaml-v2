using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> GetAsync(Guid id);

        Task<List<UserDto>> GetListAsync();

        Task<UserDto> CreateAsync(CreateUserDto input);

        Task UpdateAsync(Guid id, UpdateUserDto input);

        Task DeleteAsync(Guid id);
    }
}
