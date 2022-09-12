using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.PaymentHistories
{
    public interface IPaymentHistoryRepository : IRepository<PaymentHistory, Guid>
    {
        Task<Tuple<int, List<PaymentHistory>>> GetListAsync(int page, int perPage);
    }
}
