using Managerment.OrderRepairs;
using Managerment.ProductRepairs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/product-repair")]
    public class ProductRepairController : ManagermentController
    {
        private readonly IProductRepairAppService _productRepairAppService;
        public ProductRepairController(IProductRepairAppService productRepairAppService)
        {
            _productRepairAppService = productRepairAppService;
        }
        /// <summary>
        /// tạo đơn sửa chữa
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateAsync([FromBody]CreateUpdateOrderRepairDto input)
        {
            await _productRepairAppService.CreateAsync(input);
        }
        [HttpGet("product-repair/{id}")]
        public async Task<ProductRepairDto> GetAsync(Guid id)
        {
            return await _productRepairAppService.GetAsync(id);
        }
        [HttpGet("product-repairs")]
        public async Task<ProductRepairDto> GetListAsync(string filter)
        {
            return await _productRepairAppService.GetListAsync(filter);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, CreateUpdateProductRepairDto input)
        {
            await _productRepairAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _productRepairAppService.DeleteAsync(id);
        }
    }
}
