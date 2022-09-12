using Management.EntityFrameworkCore;
using Managerment.CashRecieptOthers;
using Management.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.CashReceiptOthers
{
    public class EfCoreCashReceiptOtherRepository : EfCoreRepository<ManagementDbContext, CashReceiptOther, Guid>, ICashReceiptOtherRepository
    {
        public EfCoreCashReceiptOtherRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
    }
}
