using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.ProductRepairs
{
    public class ProductRepairManager : DomainService
    {
        public ProductRepair CreateAsync(
               string pr_code,
               string pr_name,
               DateTime pr_date_finish,
               DateTime pr_quote_date,
               string pr_status_error,
               decimal pr_price,
               EProductRepairTypeEnum product_repair_type,
               Guid id_order_repair,
               Guid id_detail
    )
        {
            return new ProductRepair(
                GuidGenerator.Create(),
                pr_code,
                pr_name,
                pr_date_finish,
                pr_quote_date,
                pr_status_error,
                pr_price,
                product_repair_type,
                id_order_repair,
                id_detail
            );
        }
    }
}
