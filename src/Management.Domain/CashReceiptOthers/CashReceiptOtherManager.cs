using Managerment.CashReceiptTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.CashRecieptOthers
{
    public class CashReceiptOtherManager : DomainService
    {
        public CashReceiptOther CreateAsync(
            string cro_code ,
            DateTime cro_date ,
            string cro_image ,
            decimal cro_money ,
            string cro_note ,
            ECashReceiptTypeEnum cash_receipt_type,
            Guid id_cus 
            )
        {
            return new CashReceiptOther(
                GuidGenerator.Create(),
                cro_code,
                cro_date,
                cro_image,
                cro_money,
                cro_note,
                cash_receipt_type,
                id_cus
            );
    }
}
}
