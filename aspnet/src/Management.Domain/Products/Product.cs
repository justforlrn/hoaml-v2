using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Products
{
    public class Product : AuditedAggregateRoot<Guid> , ISoftDelete
    {
        public Guid Id_manu { get; set; }
        public Guid Id_sup { get; set; }
        public Guid Id_cat { get; set; }
        public Guid Id_con { get; set; }
        public Guid Id_unit { get; set; }
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
        public bool IsDeleted { get; set; }
        private Product()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Product(
               Guid id,
               Guid id_manu,
               Guid id_sup,
               Guid id_cat,
               Guid id_con,
               Guid id_unit,
               string pro_code,
               string pro_name,
               int pro_quanlity,
               int pro_min,
               int pro_max,
               decimal pro_original_cost,
               decimal pro_sell_in,
               decimal pro_sell_out,
               string pro_warranty,
               string description,
               bool is_inventory,
               bool is_allownegative
           )
           : base(id)
        {
           Id_manu = id_manu;
           Id_sup = id_sup;
           Id_cat = id_cat;
           Id_con = id_con;
           Id_unit = id_unit;
            Pro_code = pro_code;
            Pro_name = pro_name;
            Pro_quanlity = pro_quanlity;
            Pro_min = pro_min;
            Pro_max = pro_max;
            Pro_original_cost = pro_original_cost;
            Pro_sell_in = pro_sell_in;
            Pro_sell_out = pro_sell_out;
            Pro_warranty = pro_warranty;
            Description = description;
            Is_inventory = is_inventory;
            Is_allownegative = is_allownegative;
        }
    }
}
