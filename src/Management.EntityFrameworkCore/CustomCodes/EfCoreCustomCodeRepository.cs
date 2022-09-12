using Management.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.CustomCodes
{
    public class EfCoreCustomCodeRepository : EfCoreRepository<ManagementDbContext, CustomCode, Guid>, ICustomCodeRepository
    {
        public EfCoreCustomCodeRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
    }
}
