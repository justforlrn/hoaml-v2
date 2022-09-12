
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace Managerment.Manufacturers
{
    public interface IManuFacturerRepository : IRepository<Manufacturer, Guid>
    {
        Task<List<Manufacturer>> GetListAsync(int skip, int take, string filter);
    }
}
