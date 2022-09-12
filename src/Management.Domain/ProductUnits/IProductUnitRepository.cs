using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.ProductUnits
{
    public interface IProductUnitRepository : IRepository<ProductUnit, Guid>
    {
        Task<List<ProductUnit>> GetListAsync(int skip, int take, string filter);
    }
}
