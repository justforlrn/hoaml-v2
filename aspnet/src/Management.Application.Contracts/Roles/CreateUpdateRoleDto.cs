using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Roles
{
    public class CreateUpdateRoleDto
    {
        public string Roles_name { get; set; }
        public int Permission { get; set; }
    }
}
