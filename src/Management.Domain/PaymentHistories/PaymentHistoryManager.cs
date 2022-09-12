using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.PaymentHistories
{
    public class PaymentHistoryManager : DomainService
    {
        public PaymentHistory CreateAsync(
              DateTime date_pay,
              decimal money,
              Guid id_payment
  )
        {
            return new PaymentHistory(
                GuidGenerator.Create(),
                date_pay, money, id_payment
            );
        }
    }
}
