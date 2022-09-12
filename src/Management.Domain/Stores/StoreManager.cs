using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Stores
{
    public class StoreManager : DomainService
    {
        public Store CreateAsync(
               string store_name,
               string store_phone,
               string store_address,
               string store_imgURL
    )
        {
            return new Store(
               GuidGenerator.Create(),
               store_name,
               store_phone,
               store_address,
               store_imgURL
            );
        }
    }
}
