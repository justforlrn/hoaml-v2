using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.OrderWarranties
{
    public class OrderWarrantyManager : DomainService
    {
        public OrderWarranty CreateAsync(
              string qr_code,
              string text,
              Guid id_cus,
              Guid id_user,
              Guid id_pr
  )
        {
            return new OrderWarranty(
                GuidGenerator.Create(),
                qr_code,
                text,
                id_cus,
                id_user,
                id_pr
            );
        }
    }
}
