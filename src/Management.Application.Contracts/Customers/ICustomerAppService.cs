using Managerment.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> GetAsync(Guid id);

        Task<ResultPageCustomerDto> GetListAsync(int page, int perPage, string filter, DateTime fromDate, DateTime toDate, ECustomerTypeEnum? customerTypeEnum);

        Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input);

        Task UpdateAsync(Guid id, CreateUpdateCustomerDto input);

        Task DeleteAsync(Guid id);
    }
}
