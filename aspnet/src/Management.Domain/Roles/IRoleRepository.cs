using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Roles
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Task<List<Role>> GetListAsync();
    }
}
