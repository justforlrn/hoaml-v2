using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Products
{
    public class ProductDto : EntityDto<Guid>
    {
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
