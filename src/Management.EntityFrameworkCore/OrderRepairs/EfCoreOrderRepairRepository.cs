using Managerment.CustomerTypes;
using Management.EntityFrameworkCore;
using Managerment.ProductProcessRepairs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Managerment.OrderRepairs
{
    public class EfCoreOrderRepairRepository : EfCoreRepository<ManagementDbContext, OrderRepair, Guid>, IOrderRepairRepository
    {
        public EfCoreOrderRepairRepository(
           IDbContextProvider<ManagementDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        /// <summary>
        /// lấy danh sách đơn sửa chữa
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="customerTypeEnum"></param>
        /// <returns></returns>
        [Obsolete]
        public async Task<Tuple<int, List<OrderRepair>>> GetListAsync(int page, int perPage, string filter = null,
            DateTime? fromDate = null, DateTime? toDate = null, ECustomerTypeEnum? customerTypeEnum = null)
        {
            var query = from orderRepair in DbContext.OrderRepairs
                        join customer in DbContext.Customers on orderRepair.ID_cus equals customer.Id
                        where (filter == null || customer.C_name.Contains(filter) && customer.C_code.Contains(filter) && customer.C_phone.Contains(filter))
                        && fromDate == null && toDate == null || fromDate.GetValueOrDefault() <= orderRepair.CreationTime && orderRepair.CreationTime <= toDate.GetValueOrDefault()
                        && customerTypeEnum == null || customer.Customer_type == customerTypeEnum
                        select orderRepair;

            return new Tuple<int, List<OrderRepair>>(
                    query.Count(),
                    await query.ToListAsync()
                ) ;
        }
    }
}
