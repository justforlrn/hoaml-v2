using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Products
{
    public class CreateUpdateProductDto 
    {
        public Guid Id_manu { get; set; }
        public Guid Id_sup { get; set; }
        public Guid Id_cat { get; set; }
        public Guid Id_con { get; set; }
        public Guid Id_unit { get; set; }
        public string Pro_code { get; set; }
        [Required]
        public string Pro_name { get; set; }
        [Required]
        public int Pro_quanlity { get; set; }
        [Required]
        public int Pro_min { get; set; }
        [Required]
        public int Pro_max { get; set; }
        [Required]
        public decimal Pro_original_cost { get; set; }
        [Required]
        public decimal Pro_sell_in { get; set; }
        [Required]
        public decimal Pro_sell_out { get; set; }
        [Required]
        public string Pro_warranty { get; set; }
        public string Description { get; set; }
        public bool Is_inventory { get; set; }
        public bool Is_allownegative { get; set; }
    }
}
