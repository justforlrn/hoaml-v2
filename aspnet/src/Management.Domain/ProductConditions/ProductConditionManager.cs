using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.ProductConditions
{
    public class ProductConditionManager : DomainService
    {
        public ProductCondition CreateAsync(
                string cond_name
    )
        {
            return new ProductCondition(
                GuidGenerator.Create(),
                cond_name
            );
        }
    }
}
