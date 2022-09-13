using Managerment.CashRecieptOthers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.CashReceiptOthers
{
    public interface ICashReceiptOtherRepository : IRepository<CashReceiptOther, Guid>
    {

    }
}
