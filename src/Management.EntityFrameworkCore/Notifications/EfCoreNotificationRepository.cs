using Management.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Notifications
{
    public class EfCoreNotificationRepository : EfCoreRepository<ManagementDbContext, Notification, Guid>, INotificationRepository
    {
        public EfCoreNotificationRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
    {
    }
}
}
