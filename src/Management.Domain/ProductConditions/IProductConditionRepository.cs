using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.ProductConditions
{
    public interface IProductConditionRepository : IRepository<ProductCondition, Guid>
    {
        Task<List<ProductCondition>> GetListAsync(int skip, int take, string filter);
    }
}
