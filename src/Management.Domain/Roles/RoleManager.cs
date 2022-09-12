using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Roles
{
    public class RoleManager : DomainService
    {
        public Role CreateAsync(
               string roles_name,
               int permission
    )
        {
            return new Role(
                GuidGenerator.Create(),
                roles_name,
                permission
            );
        }
    }
}
