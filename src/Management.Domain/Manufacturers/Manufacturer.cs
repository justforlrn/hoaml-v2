using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Manufacturers
{
    public class Manufacturer : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Manufacturer()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Manufacturer(
               Guid id,
               string name
           )
           : base(id)
        {
            Name = name;
        }
    }
}
