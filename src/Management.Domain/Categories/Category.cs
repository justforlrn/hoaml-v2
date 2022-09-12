using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Cat_name { get; set; }
        public Guid Parent_Id { get; set; }
        private Category()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Category(
               Guid id,
               string cat_name,
               Guid parent_Id

           )
           : base(id)
        {
            Cat_name = cat_name;
            Parent_Id = parent_Id;
        }
    }
}
