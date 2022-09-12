using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<NotificationDto> GetAsync(Guid id);

        Task<ReponseListDataDto<NotificationDto>> GetListAsync(int page, int perPage, string filter);

        Task<NotificationDto> CreateAsync(CreateUpdateNotificationDto input);

        Task UpdateAsync(Guid id, CreateUpdateNotificationDto input);

        Task DeleteAsync(Guid id);
    }
}
