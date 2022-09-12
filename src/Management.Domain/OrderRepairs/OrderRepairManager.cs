using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.OrderRepairs
{
    public class OrderRepairManager : DomainService
    {
        public OrderRepair CreateAsync(
               string qr_code,
               string notes,
               Guid id_cus,
               Guid id_user
  )
        {
            return new OrderRepair(
                GuidGenerator.Create(),
                qr_code,
                notes,
                id_cus,
                id_user
            );
        }
    }
}
