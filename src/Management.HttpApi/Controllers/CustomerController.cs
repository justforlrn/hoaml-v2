using Managerment.Customers;
using Managerment.CustomerTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ManagermentController
    {
        private readonly CustomerAppService _customerAppService;
        public CustomerController(CustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [HttpPost]
        public async Task<CustomerDto> CreateAsync([FromBody] CreateUpdateCustomerDto input)
        {
            var customer = await _customerAppService.CreateAsync(input);

            return customer;
        }
        [HttpGet("customer/{id}")]
        public async Task<CustomerDto> GetAsync(Guid id)
        {
            return await _customerAppService.GetAsync(id);
        }
        [HttpGet("customers")]
        public async Task<ResultPageCustomerDto> GetListAsync(int page, int perPage, string filter, DateTime fromDate, DateTime toDate, ECustomerTypeEnum? customerTypeEnum)
        {
            return await _customerAppService.GetListAsync(page, perPage, filter, fromDate, toDate, customerTypeEnum);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody]CreateUpdateCustomerDto input)
        {
            await _customerAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _customerAppService.DeleteAsync(id);
        }
    }
}
