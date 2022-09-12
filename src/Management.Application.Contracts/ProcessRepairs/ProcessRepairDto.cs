using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.ProcessRepairs
{
    public class ProcessRepairDto : EntityDto<Guid>
    {
        public DateTime PR_date_order { get; set; }
        public string PR_status_fix { get; set; }
        public EProcessRepairType PR_process_repair { get; set; }
        public Guid Id_order_repair { get; set; }
    }
}
