using Managerment.Suppliers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/supplier")]
    public class SupplierController : ManagermentController
    {
        private readonly ISupplierAppService _supplierAppService;
        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }
        [HttpPost]
        public async Task<SupplierDto> CreateAsync([FromBody] CreateUpdateSupplierDto input)
        {
            var supplier = await _supplierAppService.CreateAsync(input);

            return supplier;
        }
        [HttpGet("supplier/{id}")]
        public async Task<SupplierDto> GetAsync(Guid id)
        {
            return await _supplierAppService.GetAsync(id);
        }
        [HttpGet("suppliers")]
        public async Task<PagedResultDto<SupplierDto>> GetListAsync(int page, int perPage, string filter)
        {
            return await _supplierAppService.GetListAsync(page, perPage, filter);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateSupplierDto input)
        {
            await _supplierAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _supplierAppService.DeleteAsync(id);
        }
    }
}
