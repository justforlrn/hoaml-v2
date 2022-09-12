using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class CreateOrderRepairDto
    {
        public string OR_code { get; set; }
        public string Notes { get; set; }
        public Guid ID_cus { get; set; }
        public Guid ID_user { get; set; }
    }
}
