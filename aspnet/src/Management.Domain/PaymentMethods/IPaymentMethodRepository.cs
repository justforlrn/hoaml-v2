using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.PaymentMethods
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod, Guid>
    {
        Task<Tuple<int, List<PaymentMethod>>> GetListAsync(int skip, int take);
    }
}
