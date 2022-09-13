using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Notifications
{
    public interface INotificationRepository : IRepository<Notification, Guid>
    {
    }
}
