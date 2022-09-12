using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Products
{
    public class EfCoreProductRepository : EfCoreRepository<ManagementDbContext, Product, Guid>, IProductRepository
    {
        public EfCoreProductRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<Tuple<int, List<Product>>> GetListAsync(int page, int perPage, string filter = null, Guid idCategory = default,
            Guid idProductCondition = default, Guid idProductUnit = default, Guid idManuFacturer = default)
        {
            var dbSet = await GetDbSetAsync();
            var result = await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    product => product.Pro_name.ToLower().Trim().Contains(filter.ToLower().Trim())
                 )
                .WhereIf(
                    idCategory != Guid.Empty,
                    product => product.Id_cat == idCategory
                 )
                 .WhereIf(
                    idProductCondition != Guid.Empty,
                    product => product.Id_con == idProductCondition

                 )
                 .WhereIf(
                    idProductUnit != Guid.Empty,
                    product => product.Id_unit == idProductUnit

                 )
                 .WhereIf(
                    idManuFacturer != Guid.Empty,
                    product => product.Id_manu == idManuFacturer

                 ).ToListAsync();
            var totalCount = result.Count;

            return new Tuple<int, List<Product>>(
                totalCount,
                result.OrderBy(x => x.CreationTime)
                        .Skip((page - 1) * perPage)
                        .Take(perPage).ToList());
    }
    }
}
