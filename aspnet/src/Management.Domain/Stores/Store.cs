using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Stores
{
    public class Store : AuditedAggregateRoot<Guid>
    {
        public string Store_name { get; set; }
        public string Store_phone { get; set; }
        public string Store_address { get; set; }
        public string Store_imgURL { get; set; }
        private Store()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Store(
               Guid id,
               string store_name,
               string store_phone,
               string store_address,
               string store_imgURL
           )
           : base(id)
        {
            Store_name = store_name;
            Store_phone = store_phone;
            Store_address = store_address;
            Store_imgURL = store_imgURL;
        }
    }
}
