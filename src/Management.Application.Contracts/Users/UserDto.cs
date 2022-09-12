using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Users
{
    public class UserDto : EntityDto<Guid>
    {
        public string U_code { get; set; }
        public string U_username { get; set; }
        public string U_password { get; set; }
        public string U_salt { get; set; }
        public string U_name { get; set; }
        public string U_email { get; set; }
        public string U_status { get; set; }
        public string U_commission { get; set; }
        public Guid Id_store { get; set; }
        public Guid Id_roles { get; set; }
    }
}
