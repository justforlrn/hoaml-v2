using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.PaymentMethods
{
    public class PaymentMethod : AuditedAggregateRoot<Guid>
    {
        public string Methods { get; set; }
        private PaymentMethod()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal PaymentMethod(
               Guid id,
               string methods
           )
           : base(id)
        {
            Methods = methods;
        }
    }
}
