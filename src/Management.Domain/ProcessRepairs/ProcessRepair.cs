using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.ProcessRepairs
{
    public class ProcessRepair : AuditedAggregateRoot<Guid>
    {
        public DateTime PR_date_order { get; set; }
        public string PR_status_fix { get; set; }
        public EProcessRepairType PR_process_repair { get; set; }
        public Guid Id_order_repair { get; set; }
        private ProcessRepair()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProcessRepair(
               Guid id,
               DateTime pr_date_order,
               string pr_status_fix,
               [NotNull]EProcessRepairType pr_process_repair,
               [NotNull]Guid id_order_repair
           )
           : base(id)
        {
            PR_date_order = pr_date_order;
            PR_status_fix = pr_status_fix;
            PR_process_repair = pr_process_repair;
            Id_order_repair = id_order_repair;
        }
    }
}
