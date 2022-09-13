using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string C_code { get; set; }
        public string C_name { get; set; }
        public string C_phone { get; set; }
        public string C_email { get; set; }
        public string C_address { get; set; }
        public string C_gender { get; set; }
        public string C_birthday { get; set; }
        public string C_imageURL { get; set; }
        public string Notes { get; set; }
        public ECustomerTypeEnum Customer_type { get; set; }
        private Customer()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Customer(
               Guid id,
               string c_code,
               string c_name,
               string c_phone,
               string c_email,
               string c_address,
               string c_gender,
               string c_birthday,
               string c_imageURL,
               string notes,
               ECustomerTypeEnum customer_type
           )
           : base(id)
        {
            C_code = c_code;
            C_name = c_name;
            C_phone = c_phone;
            C_email = c_email;
            C_address = c_address;
            C_gender = c_gender;
            C_birthday = c_birthday;
            C_imageURL = c_imageURL;
            Notes = notes;
            Customer_type = customer_type;
        }
    }
}
