using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Orders
{
    public class OrderManager : DomainService
    {
        public Order CreateAsync(
               [NotNull]string order_code,
               [NotNull] DateTime order_date,
               [NotNull] decimal total_price,
              [NotNull] decimal discount_item,
               decimal discount,
               [NotNull] int order_quantity,
               [NotNull] decimal total_money,
               [NotNull] decimal paid,
               [NotNull] decimal debt,
               decimal total_price_return,
               decimal total_quantity_return,
               string text,
               bool can_return,
               Guid id_store,
               Guid id_prod,
               Guid id_user,
               Guid id_cus,
               Guid id_history,
               Guid id_repair
  )
        {
            return new Order(
                GuidGenerator.Create(),
                order_code,
                order_date,
                total_price,
                discount_item,
                discount,
                order_quantity,
                total_money,
                paid,
                debt,
                total_price_return,
                total_quantity_return,
                text,
                can_return,
                id_store,
                id_prod,
                id_user,
                id_cus,
                id_history,
                id_repair
            );
        }
    }
}
