using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Customers
{
    public class CreateUpdateCustomerDto
    {
        public string C_name { get; set; }
        public string C_phone { get; set; }
        public string C_email { get; set; }
        public string C_address { get; set; }
        public string C_gender { get; set; }
        public string C_birthday { get; set; }
        public string C_imageURL { get; set; }
        public string Notes { get; set; }
        public ECustomerTypeEnum Customer_type { get; set; }
    }
}
