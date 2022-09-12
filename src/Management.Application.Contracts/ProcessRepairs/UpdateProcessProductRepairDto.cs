using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.ProcessRepairs
{
    public class UpdateProcessProductRepairDto
    {
        public string Status_fix { get; set; }
        public DateTime Date_finish { get; set; }
        public EProcessRepairType Process_repair_type { get; set; }
        public Guid User_id { get; set; }
    }
}
