using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.PaymentHistories
{
    public class PaymentHistoryDto : EntityDto<Guid>
    {
        public DateTime Date_pay { get; set; }
        public decimal Money { get; set; }
        public Guid ID_payment { get; set; }
    }
}
