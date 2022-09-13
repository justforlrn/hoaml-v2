using Managerment.CashReceiptTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.CashReceiptOthers
{
    public class CreateUpdateCashReceiptOtherDto
    {
        public string CRO_code { get; set; }
        public DateTime CRO_date { get; set; }
        public string CRO_image { get; set; }
        public decimal CRO_money { get; set; }
        public string CRO_note { get; set; }
        public ECashReceiptTypeEnum ID_reciept_type { get; set; }
        public Guid ID_cus { get; set; }
    }
}
