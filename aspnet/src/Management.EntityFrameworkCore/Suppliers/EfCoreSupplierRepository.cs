using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Suppliers
{
    public class EfCoreSupplierRepository : EfCoreRepository<ManagementDbContext, Supplier, Guid>, ISupplierRepository
    {
        public EfCoreSupplierRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<Supplier>> GetListAsync(int skip, int take, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    sup => sup.Name.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .OrderBy(x => x.CreationTime)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
