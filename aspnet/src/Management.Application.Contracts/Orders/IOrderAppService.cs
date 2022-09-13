using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<OrderDto> GetAsync(Guid id);

        Task<ReponseListDataDto<OrderDto>> GetListAsync(int page, int perPage, string filter);

        Task<OrderDto> CreateAsync(CreateUpdateOrderDto input);

        Task UpdateAsync(Guid id, CreateUpdateOrderDto input);

        Task DeleteAsync(Guid id);
    }
}
