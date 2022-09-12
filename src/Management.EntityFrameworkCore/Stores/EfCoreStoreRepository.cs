using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Stores
{
    public class EfCoreStoreRepository : EfCoreRepository<ManagementDbContext, Store, Guid>, IStoreRepository
    {
        public EfCoreStoreRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<Store>> GetListAsync()
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .OrderBy(x => x.CreationTime)
                .ToListAsync();          
        }
    }
}
