using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.ProductUnits
{
    public class ProductUnitDto : EntityDto<Guid>
    {
        public string Unit_name { get; set; }
    }
}
