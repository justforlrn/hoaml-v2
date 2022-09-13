using Managerment.DetailProductRepairs;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.OrderRepairs
{
    public class CreateUpdateOrderRepairDto
    {
        public List<ListProductRepairDto> Product_repair { get; set; }
        public string Notes { get; set; }
        public Guid Id_customer { get; set; }
        public Guid Id_user { get; set; }

    }
}
