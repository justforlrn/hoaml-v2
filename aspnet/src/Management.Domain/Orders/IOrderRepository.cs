using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<Tuple<int, List<Order>>> GetListAsync(int page, int perPage, string filter);
    }
}
