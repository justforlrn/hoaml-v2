using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Managerment.Manufacturers
{
    public class EfCoreManuFacturerRepository : EfCoreRepository<ManagementDbContext, Manufacturer, Guid>, IManuFacturerRepository
    {
        public EfCoreManuFacturerRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<Manufacturer>> GetListAsync(int page, int perPage, string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    manu => manu.Name.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .OrderBy(x => x.CreationTime)
                .Skip( (page -1) * perPage )
                .Take(perPage)
                .ToListAsync();
        }
    }
}
