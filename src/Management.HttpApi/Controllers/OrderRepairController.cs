using Managerment.CustomerTypes;
using Managerment.OrderRepairs;
using Managerment.Orders;
using Managerment.ProcessRepairs;
using Managerment.ProductProcessRepairs;
using Managerment.Shares;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/order-repair")]
    public class OrderRepairController : ManagermentController
    {
        private readonly IOrderRepairAppService _orderRepairAppService;
        public OrderRepairController(IOrderRepairAppService orderRepairAppService)
        {
            _orderRepairAppService = orderRepairAppService;
        }
        [HttpPost]
        public async Task<OrderRepairDto> CreateAsync([FromBody] CreateOrderRepairDto input)
        {
            var repair = await _orderRepairAppService.CreateAsync(input);

            return repair;
        }
        /// <summary>
        /// get detail đơn sữa chữa để in đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("order-repair/{id}")]
        public async Task<OrderRepairDetail> GetAsync(Guid id)
        {
            return await _orderRepairAppService.GetAsync(id);
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
        [HttpGet("order-repairs")]
        public async Task<ReponseListDataDto<OrderRepairListDto>> GetListAsync([Required] int page, [Required] int perPage, string filter, DateTime? fromDate, DateTime? toDate, ECustomerTypeEnum? customerTypeEnum)
        {
            return await _orderRepairAppService.GetListAsync(page, perPage, filter, fromDate, toDate, customerTypeEnum);
        }

        /// <summary>
        /// chỉnh sửa đơn sửa chữa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateOrderRepairDto input)
        {
            await _orderRepairAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _orderRepairAppService.DeleteAsync(id);
        }
    }
}
