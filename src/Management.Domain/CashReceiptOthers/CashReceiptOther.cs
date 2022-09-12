using Managerment.CashReceiptTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.CashRecieptOthers
{
    public class CashReceiptOther : AuditedAggregateRoot<Guid>
    {
        public string CRO_code { get; set; }
        public DateTime CRO_date { get; set; }
        public string CRO_image { get; set; }
        public decimal CRO_money { get; set; }
        public string CRO_note { get; set; }
        public ECashReceiptTypeEnum Cash_receipt_type { get; set; }
        public Guid ID_cus { get; set; }
        private CashReceiptOther()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal CashReceiptOther(
               Guid id,
               string cro_code,
               DateTime cro_date,
               string cro_image,
               decimal cro_money,
               string cro_note,
               ECashReceiptTypeEnum cash_receipt_type,
               Guid id_cus
           )
           : base(id)
        {
            CRO_code = cro_code;
            CRO_date = cro_date;
            CRO_image = cro_image;
            CRO_money = cro_money;
            CRO_note = cro_note;
            Cash_receipt_type = cash_receipt_type;
            ID_cus = id_cus;
        }
    }
}
