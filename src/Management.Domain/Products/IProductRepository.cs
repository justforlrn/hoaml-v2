using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Tuple<int, List<Product>>> GetListAsync(int skip, int take, string filter, Guid idCategory , Guid productCondition, Guid productUnit, Guid idManuFacturer);
    }
}
