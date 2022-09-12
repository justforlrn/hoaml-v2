using Managerment.CustomerTypes;
using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Customers
{
    public class EfCoreCustomerRepository : EfCoreRepository<ManagementDbContext, Customer, Guid>, ICustomerRepository
    {
        public EfCoreCustomerRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {

        }
        public async Task<Tuple<int, List<Customer>>> GetListAsync(int page, int perPage, string filter = null,
             DateTime? fromDate = null, DateTime? toDate = null, ECustomerTypeEnum? customerTypeEnum = null)
        {
            var dbSet = await GetDbSetAsync();

            var result = await dbSet
                .WhereIf(
                     fromDate.Value.Year > 1 && toDate.Value.Year > 1 ,
                     cus => fromDate.GetValueOrDefault() <= cus.CreationTime && cus.CreationTime <= toDate.GetValueOrDefault())
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    cus => cus.C_name.ToLower().Trim().Contains(filter.ToLower().Trim())
                           || cus.C_phone.ToLower().Trim().Contains(filter.ToLower().Trim())
                           || cus.C_code.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .WhereIf(customerTypeEnum != null,
                         cus => cus.Customer_type == customerTypeEnum)
                .ToListAsync();
            var totalCount = result.Count();

            return new Tuple<int, List<Customer>>(
                totalCount,
                result
                .OrderByDescending(x => x.CreationTime)
                .Skip((page - 1) * perPage)
                .Take(perPage).ToList());
        }
    }
}
