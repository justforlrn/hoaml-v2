using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.CashReceipt
{
    public class CreateUpdateCashReceiptDto
    {
        public string CR_code { get; set; }
        public DateTime CR_date { get; set; }
        public string CR_image { get; set; }
        public Guid ID_order { get; set; }
    }
}
