using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.ProductWarranties
{
    public class ProductWarranty : AuditedAggregateRoot<Guid>
    {
        public string PW_code { get; set; }
        public string PW_name { get; set; }
        public DateTime PW_date_finish { get; set; }
        public string PW_status { get; set; }
        public Guid ID_type { get; set; }
        public Guid ID_detail { get; set; }
        private ProductWarranty()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductWarranty(
               Guid id,
               string pw_code,
               string pw_name,
               DateTime pw_date_finish,
               string pw_status,
               Guid id_type,
               Guid id_detail
           )
           : base(id)
        {
            PW_code = pw_code;
            PW_name = pw_name;
            PW_date_finish = pw_date_finish;
            PW_status = pw_status;
            ID_type = id_type;
            ID_detail = id_detail;
        }
    }
}
