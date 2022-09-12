using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Suppliers
{
    public class SupplierManager : DomainService
    {
        public Supplier CreateAsync(
               [NotNull]string name,
               [NotNull] int phone,
               string address,
               string email,
               string tax,
               string url_image,
               string notes
    )
        {
            return new Supplier(
                GuidGenerator.Create(),
                name,
                phone,
                address,
                email,
                tax,
                url_image,
                notes
            );
        }
    }
}
