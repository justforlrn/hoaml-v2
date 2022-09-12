using Managerment.DetailProductRepairs;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class DetailListProductRepairDto
    {
        public Guid ID_order_repair { get; set; }
        public Guid ID_detail { get; set; }
        public string PR_code { get; set; }
        public string PR_Name { get; set; }
        public DetailProductRepairDto Detail_product_repair { get; set; }
        public EProductRepairTypeEnum PR_repair_type { get; set; }
        public string PR_repair_type_name { get; set; }
        public string PR_status_error { get; set; }
        public decimal PR_price { get; set; }
        public DateTime PR_date_finish { get; set; }
    }
}
