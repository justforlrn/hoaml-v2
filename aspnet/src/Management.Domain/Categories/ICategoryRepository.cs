using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Categories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<List<Category>> GetListAsync(Guid? parent_id);
        Task<List<Category>> GetListAsyncByListId(List<Guid> listCateId);
        Task<List<Category>> GetListByParentIdAsync(Guid parent_id);
    }
}
