using Managerment.ProductProcessRepairs;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.ProcessRepairs
{
    public class ProcessRepairDetailDto
    {
        public string Phone { get; set; }
        public string PR_name { get; set; }
        public string Product_repair_type_name { get; set; }
        public string Status_error { get; set; }
        public DateTime PR_date_order { get; set; }
        public DateTime Receipt_date { get; set; }
        public decimal PR_price { get; set; }
        public DateTime Date_finish { get; set; }
        public string Process_repair_type_name { get; set; }
    }
}
