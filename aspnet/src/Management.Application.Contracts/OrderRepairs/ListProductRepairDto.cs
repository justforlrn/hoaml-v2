using Managerment.DetailProductRepairs;
using Managerment.ProductRepairs;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class ListProductRepairDto
    {
        public string PR_code { get; set; }
        public string PR_Name { get; set; }
        public DetailProductRepairCreateOrderDetailDto Detail_product_pepairs { get; set; }
        public EProductRepairTypeEnum PR_repair_type { get; set; }
        public string PR_status_error { get; set; }
        public decimal PR_price { get; set; }
        public DateTime PR_date_finish { get; set; }
        public DateTime PR_quote_date { get; set; }
    }
}
