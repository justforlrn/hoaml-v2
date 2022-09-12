using Management.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.Categories
{
    public class EfCoreCategoryRepository : EfCoreRepository<ManagementDbContext, Category, Guid>, ICategoryRepository
    {
        public EfCoreCategoryRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {

        }
        public async Task<List<Category>> GetListAsync(Guid? parent_id = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .Where(x => x.Parent_Id == default)
                .WhereIf(
                    parent_id != null,
                    cat => cat.Parent_Id == parent_id
                 )
                .OrderBy(x => x.CreationTime)
                .ToListAsync();
        }
        [Obsolete]
        public async Task<List<Category>> GetListAsyncByListId(List<Guid> listCateId)
        {
            var listCate = await DbSet.Where(x => listCateId.Contains(x.Id)).ToListAsync();
            return listCate;
        }

        [Obsolete]
        public async Task<List<Category>> GetListByParentIdAsync(Guid id)
        {
            var reult = DbSet.Where(x => x.Parent_Id == id && x.Id != id);
            return await reult.ToListAsync();
        }
    }
}
