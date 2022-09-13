using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.PaymentMethods
{
    public class PaymentMethodManager : DomainService
    {
        public PaymentMethod CreateAsync(
            string methods
  )
        {
            return new PaymentMethod(
                GuidGenerator.Create(),
                methods
            );
        }
    }
}
