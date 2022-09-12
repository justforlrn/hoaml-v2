using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Suppliers
{
    public class Supplier : AuditedAggregateRoot<Guid>
    {
      public string Name { get; set; }
      public int Phone { get; set; }
      public string Address { get; set; }
      public string Email { get; set; }
      public string Tax { get; set; }
      public string URL_image { get; set; }
      public string Notes { get; set; }
        private Supplier()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Supplier(
               Guid id,
               string name,
               int phone,
               string address,
               string email,
               string tax,
               string url_image,
               string notes
           )
           : base(id)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
            Tax = tax;
            URL_image = url_image;
            Notes = notes;
        }

    }
}
