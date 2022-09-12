using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.ProductConditions
{
    public class ProductCondition : AuditedAggregateRoot<Guid>
    {
        public string Cond_name { get; set; }
        private ProductCondition()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductCondition(
               Guid id,
               string cond_name
           )
           : base(id)
        {
            Cond_name = cond_name;
        }
    }
}
