using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Products
{
    public class ListProductDto
    {
        public Guid Id { get; set; }
        public string Manufacturer_name { get; set; }
        public string Supplier_name { get; set; }
        public string Category_name { get; set; }
        public string Condition_name { get; set; }
        public string Unit_name { get; set; }
        public string Pro_code { get; set; }
        public string Pro_name { get; set; }
        public int Pro_quanlity { get; set; }
        public int Pro_min { get; set; }
        public int Pro_max { get; set; }
        public decimal Pro_original_cost { get; set; }
        public decimal Pro_sell_in { get; set; }
        public decimal Pro_sell_out { get; set; }
        public string Pro_warranty { get; set; }
        public string Description { get; set; }
        public bool Is_inventory { get; set; }
        public bool Is_allownegative { get; set; }
    }
}
