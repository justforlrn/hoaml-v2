using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Users
{
    public class UserManager : DomainService
    {
        public User CreateAsync(
               [NotNull] string u_code,
               [NotNull]string u_username,
               [NotNull] string u_password,
               [NotNull] string u_salt,
               [NotNull] string u_name,
               [NotNull] string u_email,
               [NotNull] string u_status,
               [NotNull] string u_commission,
               [NotNull] Guid id_store,
               [NotNull] Guid id_roles
   )
        {
            return new User(
                GuidGenerator.Create(),
                u_code,
                u_username,
                u_password,
                u_salt,
                u_name,
                u_email,
                u_status,
                u_commission,
                id_store,
                id_roles
            );
        }
    }
}
