using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Suppliers
{
    public class CreateUpdateSupplierDto
    {

        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Tax { get; set; }
        public string URL_image { get; set; }
        public string Notes { get; set; }
    }
}
