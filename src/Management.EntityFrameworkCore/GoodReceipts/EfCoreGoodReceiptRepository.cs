using Managerment.CustomerTypes;
using Management.EntityFrameworkCore;
using Managerment.GoodsReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.GoodReceipts
{
    public class EfCoreGoodReceiptRepository : EfCoreRepository<ManagementDbContext, GoodsReceipt, Guid>, IGoodReceiptRepository
    {
        public EfCoreGoodReceiptRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
    }
}
