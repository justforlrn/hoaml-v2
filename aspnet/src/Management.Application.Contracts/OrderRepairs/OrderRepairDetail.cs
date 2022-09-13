using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class OrderRepairDetail
    {
        public List<DetailListProductRepairDto> Product_repair { get; set; }
        public string Notes { get; set; }
        public string Customer_name { get; set; }
    }
}
