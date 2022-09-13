using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Users
{
    public class EfCoreUserRepository : EfCoreRepository<ManagementDbContext, User, Guid>, IUserRepository
    {
        public EfCoreUserRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<User>> GetListAsync()
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .OrderBy(x => x.CreationTime)
                .ToListAsync();
        }
    }
}
