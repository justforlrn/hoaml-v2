using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.ProductUnits
{
    public class ProductUnit : AuditedAggregateRoot<Guid>
    {
        public string Unit_name { get; set; }
        private ProductUnit()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductUnit(
               Guid id,
               string unit_name
           )
           : base(id)
        {
            Unit_name = unit_name;
        }
    }
}
