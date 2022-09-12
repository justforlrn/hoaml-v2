using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Products
{
    public class ProductManager : DomainService
    {
        public Product CreateAsync(
               Guid id_manu,
               Guid id_sup,
               Guid id_cat,
               Guid id_con,
               Guid id_unit,
               string pro_code,
               [NotNull] string pro_name,
               [NotNull] int pro_quanlity,
               [NotNull] int pro_min,
               [NotNull] int pro_max,
               [NotNull] decimal pro_original_cost,
               [NotNull] decimal pro_sell_in,
               [NotNull] decimal pro_sell_out,
               [NotNull] string pro_warranty,
               string description,
               bool is_inventory,
               bool is_allownegative
   )
        {
            return new Product(
                GuidGenerator.Create(),
                id_manu,
                id_sup,
                id_cat,
                id_con,
                id_unit,
                pro_code,
                pro_name,
                pro_quanlity,
                pro_min,
                pro_max,
                pro_original_cost,
                pro_sell_in,
                pro_sell_out,
                pro_warranty,
                description,
                is_inventory,
                is_allownegative
            );
        }
    }
}
