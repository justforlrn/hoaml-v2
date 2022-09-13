using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.PaymentMethods
{
    public class EfCorePaymentMethodRepository : EfCoreRepository<ManagementDbContext, PaymentMethod, Guid>, IPaymentMethodRepository
    {
        public EfCorePaymentMethodRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<Tuple<int, List<PaymentMethod>>> GetListAsync(int page, int perPage)
        {
            var dbSet = await GetDbSetAsync();

            var result = await dbSet.ToListAsync();
            var totalCount = result.Count;

            return new Tuple<int, List<PaymentMethod>>(
                totalCount,
                result.OrderBy(x => x.CreationTime)
                .Skip((page - 1) * perPage)
                .Take(perPage).ToList());
        }
    }
}
