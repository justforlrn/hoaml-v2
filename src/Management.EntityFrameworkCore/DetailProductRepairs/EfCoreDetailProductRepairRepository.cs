using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.DetailProductRepairs
{
    public class EfCoreDetailProductRepairRepository : EfCoreRepository<ManagementDbContext, DetailProductRepair, Guid>, IDetailProductRepairRepository
    {
        public EfCoreDetailProductRepairRepository(
         IDbContextProvider<ManagementDbContext> dbContextProvider)
         : base(dbContextProvider)
        {

        }
        public async Task<List<DetailProductRepair>> GetListAsync()
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .OrderBy(x => x.CreationTime)
                .ToListAsync();
        }
    }
}
