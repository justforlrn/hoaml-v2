using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.PaymentHistories
{
    public class PaymentHistory : AuditedAggregateRoot<Guid>
    {
        public DateTime Date_pay { get; set; }
        public decimal Money { get; set; }
        public Guid ID_payment { get; set; }
        private PaymentHistory()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal PaymentHistory(
              Guid id,
              DateTime date_pay,
              decimal money,
              Guid id_payment
           )
           : base(id)
        {
            Date_pay = date_pay;
            Money = money;
            ID_payment = id_payment;
        }
    }
}
