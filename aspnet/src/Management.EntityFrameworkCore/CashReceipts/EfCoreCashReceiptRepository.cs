using Management.EntityFrameworkCore;
using Managerment.CashReceiptOthers;
using Management.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.CashReceipts
{
    public class EfCoreCashReceiptRepository : EfCoreRepository<ManagementDbContext, CashReceipt, Guid>, ICashReceiptRepository
    {
        public EfCoreCashReceiptRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
    }
}
