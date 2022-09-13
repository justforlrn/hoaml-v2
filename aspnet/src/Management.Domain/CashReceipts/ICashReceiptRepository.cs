using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.CashReceipts
{
    public interface ICashReceiptRepository : IRepository<CashReceipt, Guid>
    {
    }
}
