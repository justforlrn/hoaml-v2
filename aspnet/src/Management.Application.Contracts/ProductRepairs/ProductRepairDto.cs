using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.ProductRepairs
{
    public class ProductRepairDto : EntityDto<Guid>
    {
        public string PR_code { get; set; }
        public string PR_name { get; set; }
        public DateTime PR_date_finish { get; set; }
        public DateTime PR_quote_date { get; set; }
        public string Text { get; set; }
        public decimal PR_price { get; set; }
        public EProductRepairTypeEnum Product_repair_type { get; set; }
        public Guid ID_detail { get; set; }
    }
}
