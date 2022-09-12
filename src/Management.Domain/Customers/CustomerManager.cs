using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Customers
{
    public class CustomerManager : DomainService
    {
        public Customer CreateAsync(
         string c_code,
         [NotNull] string c_name,
         [NotNull] string c_phone,
         string c_email,
         [NotNull] string c_address,
         [NotNull] string c_gender,
         [NotNull] string c_birthday,
         [NotNull] string c_imageURL,
         string notes,
         ECustomerTypeEnum customer_type
         )
        {
            return new Customer(
                GuidGenerator.Create(),
                c_code,
                c_name,
                c_phone,
                c_email,
                c_address,
                c_gender,
                c_birthday,
                c_imageURL,
                notes,
                customer_type
            );
        }
    }
}
