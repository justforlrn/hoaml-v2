using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<ManagementDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<Tuple<int, List<Order>>> GetListAsync(int page, int perPage, string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            var result = await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    order => order.Order_code.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .ToListAsync();
            var totalCount = result.Count;

            return new Tuple<int, List<Order>>(
                totalCount,
                result.OrderBy(x => x.CreationTime)
                .Skip((page - 1) * perPage)
                .Take(perPage).ToList());
        }
    }
}
