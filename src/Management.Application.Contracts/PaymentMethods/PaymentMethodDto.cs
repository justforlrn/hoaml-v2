using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.PaymentMethods
{
    public class PaymentMethodDto : EntityDto<Guid>
    {
        public string Methods { get; set; }
    }
}
