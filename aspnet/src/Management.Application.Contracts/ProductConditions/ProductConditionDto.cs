using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.ProductConditions
{
    public class ProductConditionDto : EntityDto<Guid>
    {
        public string Cond_name { get; set; }
    }
}
