using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Roles
{
    public class RoleDto : EntityDto<Guid>
    {
        public string Roles_name { get; set; }
        public int Permission { get; set; }
    }
}
