using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Orders
{
    public class CreateUpdateOrderDto
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
    }
}
