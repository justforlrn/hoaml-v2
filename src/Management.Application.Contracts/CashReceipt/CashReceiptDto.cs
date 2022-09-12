using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.CashReceipt
{
    public class CashReceiptDto : EntityDto<Guid>
    {
        public string CR_code { get; set; }
        public DateTime CR_date { get; set; }
        public string CR_image { get; set; }
        public Guid ID_order { get; set; }
    }
}
