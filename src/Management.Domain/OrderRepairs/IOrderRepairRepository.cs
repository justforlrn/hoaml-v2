using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.OrderRepairs
{
    public interface IOrderRepairRepository : IRepository<OrderRepair, Guid>
    {
        Task<Tuple<int, List<OrderRepair>>> GetListAsync(int page, int perPage, string filter,
     DateTime? fromDate, DateTime? toDate, ECustomerTypeEnum? customerTypeEnum);
    }
}
