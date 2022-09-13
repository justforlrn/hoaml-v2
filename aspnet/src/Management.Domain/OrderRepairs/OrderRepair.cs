using Managerment.Customers;
using Managerment.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.OrderRepairs
{
    public class OrderRepair : AuditedAggregateRoot<Guid>
    {
        public string OR_code { get; set; }
        public string Notes { get; set; }
        public Guid ID_cus { get; set; }
        public Guid ID_user { get; set; }
        private OrderRepair()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal OrderRepair(
               Guid id,
               string or_code,
               string notes,
               Guid id_cus,
               Guid id_user
           )
           : base(id)
        {
            OR_code = or_code;
            Notes = notes;
            ID_cus = id_cus;
            ID_user = id_user;
        }
    }
}
