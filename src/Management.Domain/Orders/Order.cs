using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.Orders
{
    public class Order : AuditedAggregateRoot<Guid> , ISoftDelete
    {
        public string Order_code { get; set; }
        public DateTime Order_date { get; set; }
        public decimal Total_price { get; set; }
        public decimal Discount_item { get; set; }
        public decimal Discount { get; set; }
        public int Order_quantity { get; set; }
        public decimal Total_money { get; set; }
        public decimal Paid { get; set; }
        public decimal Debt { get; set; }
        public decimal Total_price_return { get; set; }
        public decimal Total_quantity_return { get; set; }
        public string Text { get; set; }
        public bool Can_return { get; set; }
        public Guid Id_store { get; set; }
        public Guid Id_prod { get; set; }
        public Guid Id_user { get; set; }
        public Guid Id_cus { get; set; }
        public Guid Id_history { get; set; }
        public Guid Id_repair { get; set; }
        public bool IsDeleted { get; set; }

        private Order()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Order(
               Guid id,
               string order_code,
               DateTime order_date,
               decimal total_price,
               decimal discount_item,
               decimal discount,
               int order_quantity,
               decimal total_money,
               decimal paid,
               decimal debt,
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
           : base(id)
        {
            Order_code = order_code;
            Order_date = order_date;
            Total_price = total_price;
            Discount_item = discount_item;
            Discount = discount;
            Order_quantity = order_quantity;
            Total_money = total_money;
            Paid = paid;
            Debt = debt;
            Total_price_return = total_price_return;
            Total_quantity_return = total_quantity_return;
            Text = text;
            Can_return = can_return;
            Id_store = id_store;
            Id_prod = id_prod;
            Id_user = id_user;
            Id_cus = id_cus;
            Id_history = id_history;
            Id_repair = id_repair;
        }
    }
}
