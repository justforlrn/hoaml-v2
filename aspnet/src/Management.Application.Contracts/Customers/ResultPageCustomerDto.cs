using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Customers
{
    public class ResultPageCustomerDto
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total_pages { get; set; }
        public int Count { get; set; }
        public List<CustomerListDto> Data { get; set; }
    }
}
