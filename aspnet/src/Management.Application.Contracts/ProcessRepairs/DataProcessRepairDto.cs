using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.ProcessRepairs
{
    public class DataProcessRepairDto
    {
        public Guid Id_process_repair { get; set; }
        public Guid Id_product_repair { get; set; }
        public Guid Id_order_repair { get; set; }
        public Guid Id_customer { get; set; }
        public string Cus_name { get; set; }
        public string Order_repair_code { get; set; }
        public string Product_repair_code { get; set; }
        public string Model { get; set; }
        public EProcessRepairType Process_repair_type { get; set; }
        public string Process_repair_type_name { get; set; }
        public string Status_error { get; set; }
        public string Status_fix { get; set; }
        public DateTime Received_date { get; set; }
        public DateTime Quote_date { get; set; }
        public decimal Fix_price { get; set; }
        public DateTime Date_finish { get; set; }
        public string User_name_fix { get; set; }
    }
}
