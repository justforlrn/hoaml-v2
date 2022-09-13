using Managerment.ProductUnits;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/product-unit")]
    public class ProductUnitController : ManagermentController
    {
        private readonly IProductUnitAppService _productUnitAppService;
        public ProductUnitController(IProductUnitAppService productUnitAppService)
        {
            _productUnitAppService = productUnitAppService;
        }
        [HttpPost]
        public async Task<ProductUnitDto> CreateAsync([FromBody] CreateUpdateProductUnitDto input)
        {
            var product = await _productUnitAppService.CreateAsync(input);

            return product;
        }
        [HttpGet("product-unit/{id}")]
        public async Task<ProductUnitDto> GetAsync(Guid id)
        {
            return await _productUnitAppService.GetAsync(id);
        }
        [HttpGet("products")]
        public async Task<PagedResultDto<ProductUnitDto>> GetListAsync(int page, int perPage, string filter)
        {
            return await _productUnitAppService.GetListAsync(page, perPage, filter);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateProductUnitDto input)
        {
            await _productUnitAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _productUnitAppService.DeleteAsync(id);
        }
    }
}
