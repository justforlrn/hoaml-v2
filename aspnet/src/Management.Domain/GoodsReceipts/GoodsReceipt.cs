using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.GoodsReceipts
{
    public class GoodsReceipt : AuditedAggregateRoot<Guid>
    {
        public string Receipt_code { get; set; }
        public DateTime Receipt_date { get; set; }
        public decimal Total_price { get; set; }
        public decimal Discount { get; set; }
        public int Receipt_quantity { get; set; }
        public decimal Total_money { get; set; }
        public decimal Paid { get; set; }
        public decimal Debt { get; set; }
        public decimal Total_price_return { get; set; }
        public string Notes { get; set; }
        public bool Can_return { get; set; }
        public bool Is_delete { get; set; }
        public Guid Id_store { get; set; }
        public Guid Id_cus { get; set; }
        public Guid Id_prod { get; set; }
        public Guid Id_user { get; set; }
        public Guid Id_order { get; set; }
        public Guid Id_payment { get; set; }
        private GoodsReceipt()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal GoodsReceipt(
               Guid id,
               string receipt_code,
               DateTime receipt_date,
               decimal total_price,
               decimal discount,
               int receipt_quantity,
               decimal total_money,
               decimal paid,
               decimal debt,
               decimal total_price_return,
               string notes,
               bool can_return,
               Guid id_store,
               Guid id_cus,
               Guid id_prod,
               Guid id_user,
               Guid id_order,
               Guid id_payment
           )
           : base(id)
        {
            Receipt_code = receipt_code;
            Receipt_date = receipt_date;
            Total_price = total_price;
            Discount = discount;
            Receipt_quantity = receipt_quantity;
            Total_money = total_money;
            Paid = paid;
            Debt = debt;
            Total_price_return = total_price_return;
            Notes = notes;
            Can_return = can_return;
            Id_store = id_store;
            Id_cus = id_cus;
            Id_prod = id_prod;
            Id_user = id_user;
            Id_order = id_order;
            Id_payment = id_payment;
        }
    }
}
