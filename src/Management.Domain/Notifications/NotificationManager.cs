using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Notifications
{
    public class NotificationManager : DomainService
    {
        public Notification CreateAsync(
               string description,
               bool is_seen,
               Guid id_user,
               Guid id_repair
    )
        {
            return new Notification(
                GuidGenerator.Create(),
                description,
                is_seen, 
                id_user, 
                id_repair
            );
        }
    }
}
