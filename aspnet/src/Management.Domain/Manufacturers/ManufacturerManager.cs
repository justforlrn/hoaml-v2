using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Manufacturers
{
    public class ManufacturerManager : DomainService
    {
        public Manufacturer CreateAsync(
            [NotNull]string name
    )
        {
            return new Manufacturer(
                GuidGenerator.Create(),
                name
            );
        }
    }
}
