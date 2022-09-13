using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Manufacturers
{
    public class ManufacturerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
