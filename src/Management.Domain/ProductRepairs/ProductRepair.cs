using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.ProductRepairs
{
    public class ProductRepair : AuditedAggregateRoot<Guid>
    {
        public string PR_code { get; set; }
        public string PR_name { get; set; }
        public DateTime PR_date_finish { get; set; }
        public DateTime PR_quote_date { get; set; }
        public string PR_status_error { get; set; }
        public decimal PR_price { get; set; }
        public EProductRepairTypeEnum Product_repair_type { get; set; }
        public Guid ID_order_repair { get; set; }
        public Guid ID_detail { get; set; }
        private ProductRepair()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductRepair(
               Guid id,
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
           : base(id)
        {
            PR_code = pr_code;
            PR_name = pr_name;
            PR_date_finish = pr_date_finish;
            PR_quote_date = pr_quote_date;
            PR_status_error = pr_status_error;
            PR_price = pr_price;
            Product_repair_type = product_repair_type;
            PR_status_error = pr_status_error;
            ID_order_repair = id_order_repair;
            ID_detail = id_detail;
        }
    }
}
