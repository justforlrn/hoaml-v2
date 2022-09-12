using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.ProcessRepairs
{
    public class ListProcessRepairDto
    {
        public int Checking_count { get; set; }
        public int Quote_count { get; set; }
        public int Fixing_count { get; set; }
        public int Fixed_count { get; set; }
        public int Return_customer { get; set; }
        public int Expected_revenue { get; set; }
        public List<DataProcessRepairDto> Data_process_repair { get; set; }
    }
}
