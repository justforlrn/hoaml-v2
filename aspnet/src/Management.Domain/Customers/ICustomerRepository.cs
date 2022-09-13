using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Task<Tuple<int, List<Customer>>> GetListAsync(int page, int perPage, string filter, DateTime? fromDate, DateTime? toDate , ECustomerTypeEnum? customerTypeEnum);
    }
}
