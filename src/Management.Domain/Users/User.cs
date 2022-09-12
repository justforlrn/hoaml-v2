using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Users
{
    public class User : AuditedAggregateRoot<Guid>
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
        private User()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal User(
               Guid id,
               string u_code,
               string u_username,
               string u_password,
               string u_salt,
               string u_name,
               string u_email,
               string u_status,
               string u_commission,
               Guid id_store,
               Guid id_roles
           )
           : base(id)
        {
            U_code = u_code;
            U_username = u_username;
            U_password = u_password;
            U_salt = u_salt;
            U_name = u_name;
            U_email = u_email;
            U_status = u_status;
            U_commission = u_commission;
            Id_store = id_store;
            Id_roles = id_roles;
        }
    }
}
