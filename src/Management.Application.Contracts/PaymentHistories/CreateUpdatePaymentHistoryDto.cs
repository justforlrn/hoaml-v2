using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.PaymentHistories
{
    public class CreateUpdatePaymentHistoryDto
    {
        public DateTime Date_pay { get; set; }
        public decimal Money { get; set; }
        public Guid ID_payment { get; set; }
    }
}
