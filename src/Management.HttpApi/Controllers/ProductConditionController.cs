using Managerment.ProductConditions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/product-condition")]
    public class ProductConditionController : ManagermentController
    {
        private readonly IProductConditionAppService _productConditionAppService;
        public ProductConditionController(IProductConditionAppService productConditionAppService)
        {
            _productConditionAppService = productConditionAppService;
        }
        [HttpPost]
        public async Task<ProductConditionDto> CreateAsync([FromBody] CreateUpdateProductConditionDto input)
        {
            var product = await _productConditionAppService.CreateAsync(input);

            return product;
        }
        [HttpGet("product-condition/{id}")]
        public async Task<ProductConditionDto> GetAsync(Guid id)
        {
            return await _productConditionAppService.GetAsync(id);
        }

        [HttpGet("products")]
        public async Task<PagedResultDto<ProductConditionDto>> GetListAsync(int page, int perPage, string filter)
        {
            return await _productConditionAppService.GetListAsync(page, perPage, filter);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateProductConditionDto input)
        {
            await _productConditionAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _productConditionAppService.DeleteAsync(id);
        }
    }
}
