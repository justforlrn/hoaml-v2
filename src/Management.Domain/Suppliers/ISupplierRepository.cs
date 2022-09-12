using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Suppliers
{
    public interface ISupplierRepository : IRepository<Supplier, Guid>
    {
        Task<List<Supplier>> GetListAsync(int skip, int take, string filter = null);
    }
}
