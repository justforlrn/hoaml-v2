using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.DetailProductRepairs
{
    public interface IDetailProductRepairRepository : IRepository<DetailProductRepair, Guid>
    {
        Task<List<DetailProductRepair>> GetListAsync();
    }
}
