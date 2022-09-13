using Managerment.ProductProcessRepairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.ProcessRepairs
{
    public class ProcessRepairManager : DomainService
    {
        public ProcessRepair CreateAsync(
               DateTime pr_date_order,
               string pr_status_fix,
               EProcessRepairType pr_process_repair,
               Guid id_order_repair
    )
        {
            return new ProcessRepair(
                GuidGenerator.Create(),
                pr_date_order,
                pr_status_fix,
                pr_process_repair,
                id_order_repair
            );
        }
    }
}
