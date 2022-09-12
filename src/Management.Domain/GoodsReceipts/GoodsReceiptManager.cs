using System;
using Volo.Abp.Domain.Services;

namespace Managerment.GoodsReceipts
{
    public class GoodsReceiptManager : DomainService
    {
        public GoodsReceipt CreateAsync(
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
        {
            return new GoodsReceipt(
                GuidGenerator.Create(),
                receipt_code,
                receipt_date,
                total_price,
                discount,
                receipt_quantity,
                total_money,
                paid,
                debt,
                total_price_return,
                notes,
                can_return,
                id_store,
                id_cus,
                id_prod,
                id_user,
                id_order,
                id_payment
            );
        }
    }
}


