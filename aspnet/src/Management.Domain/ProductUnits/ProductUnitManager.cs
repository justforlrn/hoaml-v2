using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.ProductUnits
{
    public class ProductUnitManager : DomainService
    {
        public ProductUnit CreateAsync(
               string unit_name
    )
        {
            return new ProductUnit(
                GuidGenerator.Create(),
                unit_name
            );
        }
    }
}
