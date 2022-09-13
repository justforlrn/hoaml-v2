using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.ProductConditions
{
    public class EfCoreProductConditionRepository : EfCoreRepository<ManagementDbContext, ProductCondition, Guid>, IProductConditionRepository
    {
        public EfCoreProductConditionRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<ProductCondition>> GetListAsync(int page, int perPage, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    pd_condition => pd_condition.Cond_name.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .OrderBy(x => x.CreationTime)
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();
        }
    }
}
