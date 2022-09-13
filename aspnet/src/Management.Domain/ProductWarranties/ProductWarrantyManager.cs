using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.ProductWarranties
{
    public class ProductWarrantyManager : DomainService
    {
        public ProductWarranty CreateAsync(
               string pw_code,
               string pw_name,
               DateTime pw_date_finish,
               string pw_status,
               Guid id_type,
               Guid id_detail
    )
        {
            return new ProductWarranty(
                GuidGenerator.Create(),
                pw_code,
                pw_name,
                pw_date_finish,
                pw_status,
                id_type,
                id_detail
            );
        }
    }
}
