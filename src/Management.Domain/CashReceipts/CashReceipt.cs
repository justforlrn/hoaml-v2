using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.CashReceipts
{
    public class CashReceipt : AuditedAggregateRoot<Guid>
    {
        public string CR_code { get; set; }
        public DateTime CR_date { get; set; }
        public string CR_image { get; set; }
        public Guid ID_order { get; set; }
        private CashReceipt()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal CashReceipt(
               Guid id,
               string cr_code,
               DateTime cr_date,
               string cr_image,
               Guid id_order
           )
           : base(id)
        {
            CR_code = cr_code;
            CR_date = cr_date;
            CR_image = cr_image;
            ID_order = id_order;
        }
    }

}
