using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.ProductUnits
{
    public class EfCoreProductUnitRepository : EfCoreRepository<ManagementDbContext, ProductUnit, Guid>, IProductUnitRepository
    {
        public EfCoreProductUnitRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<ProductUnit>> GetListAsync(int page, int perPage, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    unit => unit.Unit_name.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .OrderBy(x => x.CreationTime)
                .Skip((page-1) * perPage)
                .Take(perPage)
                .ToListAsync();
        }
    }
}
