using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class OrderRepairListDto
    {
        public Guid Id { get; set; }
        public string Order_repair_code { get; set; }
        public string Cus_phone { get; set; }
        public string Cus_name { get; set; }
        public string Customer_type { get; set; }
        public DateTime CreationTime { get; set; }
        public string Store_name { get; set; }
        public string User_name { get; set; }
        public int Amount { get; set; }
    }
}
