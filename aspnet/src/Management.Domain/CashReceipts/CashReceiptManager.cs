using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.CashReceipts
{
    public class CashReceiptManager : DomainService
    {
        public CashReceipt CreateAsync(
            [NotNull]string cr_code ,
            [NotNull] DateTime cr_date,
            string cr_image,
            Guid id_order
            )
        {
            return new CashReceipt(
                GuidGenerator.Create(),
                cr_code,
                cr_date,
                cr_image,
                id_order
            );
        }
    }
}
