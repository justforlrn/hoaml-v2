using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.ProcessRepairs
{
    public class UpdateProcessRepairDto
    {
        public DateTime PR_date_order { get; set; }
        public string PR_status_fix { get; set; }
        public EProcessRepairType PR_process_repair { get; set; }
    }
}
