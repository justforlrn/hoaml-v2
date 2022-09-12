using Managerment.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/products")]
    public class ProductController : ManagermentController
    {
        private readonly IProductAppService _productService;
        public ProductController(IProductAppService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ProductDto> CreateAsync([FromBody]CreateUpdateProductDto input)
        {
            var product = await _productService.CreateAsync(input);

            return product;
        }
        [HttpGet("product/{id}")]
        public async Task<ProductDto> GetAsync(Guid id)
        {
            return await _productService.GetAsync(id);
        }
        [HttpGet("products")]
        public async Task<ResultPageProductDto> GetListAsync(int page, int perPage, string filter, Guid idCategory, Guid idProductCondition, Guid idProductUnit, Guid idManuFacturer)
        {
            return await _productService.GetListAsync(page, perPage, filter,idCategory,idProductCondition,idProductUnit, idManuFacturer);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody]CreateUpdateProductDto input)
        {
            await _productService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
