using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Roles
{
    public class Role : AuditedAggregateRoot<Guid>
    {
        public string Roles_name { get; set; }
        public int Permission { get; set; }

        private Role()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Role(
               Guid id,
               string roles_name,
               int permission
           )
           : base(id)
        {
            Roles_name = roles_name;
            Permission = permission;
        }
    }
}
