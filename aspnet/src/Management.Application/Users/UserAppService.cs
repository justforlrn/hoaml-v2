using Management;
using Managerment.CustomCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Users
{
    [RemoteService(IsEnabled = false)]
    public class UserAppService : ManagementAppService, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager _userManager;
        private readonly CustomCodeAppService _customCodeAppService;

        public UserAppService(
            IUserRepository userRepository,
            UserManager userManager,
            CustomCodeAppService customCodeAppService)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _customCodeAppService = customCodeAppService;
        }
        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            if (await _userRepository.AnyAsync(x => x.U_email == input.U_email || (input.U_code != null && x.U_code == input.U_code)))
            {
                throw new UserFriendlyException("Email hoặc mã nhân viên đã tồn tại");
            }
            else
            {
                try
                {
                    var userCode = input.U_code ?? await _customCodeAppService.GenerateCode("NV");

                    var user = _userManager.CreateAsync(userCode, input.U_name, input.U_password, input.U_salt, input.U_name,
                                                           input.U_email, input.U_status, input.U_commission, input.Id_store, input.Id_roles);

                    await _userRepository.InsertAsync(user);

                    await _customCodeAppService.UpdateAsync("NV");

                    return ObjectMapper.Map<User, UserDto>(user);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<List<UserDto>> GetListAsync()
        {
            var users = await _userRepository.GetListAsync();
            return ObjectMapper.Map<List<User>, List<UserDto>>(users);
        }

        public async Task UpdateAsync(Guid id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);

            user.U_username = input.U_username;
            user.U_password = input.U_password;
            user.U_salt = input.U_salt;
            user.U_name = input.U_name;
            user.U_email = input.U_email;
            user.U_status = input.U_status;
            user.U_commission = input.U_commission;
            user.Id_store = input.Id_store;
            user.Id_roles = input.Id_roles;

            await _userRepository.UpdateAsync(user);
        }
    }
}
