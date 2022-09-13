using Managerment.CustomerTypes;
using Managerment.OrderRepairs;
using Managerment.ProcessRepairs;
using Managerment.ProductProcessRepairs;
using Managerment.Shares;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/process_repair")]
    public class ProcessRepairController : ManagermentController
    {
        private readonly IOrderRepairAppService _orderRepairAppService;
        private readonly IProcessRepairAppService _processRepairAppService;
        public ProcessRepairController(IOrderRepairAppService orderRepairAppService, IProcessRepairAppService processRepairAppService)
        {
            _orderRepairAppService = orderRepairAppService;
            _processRepairAppService = processRepairAppService;
        }

        /// <summary>
        /// lấy detail prepair_process
        /// </summary>
        /// <param name="process_repair_id"></param>
        /// <param name="product_repair_id"></param>
        /// <param name="customer_id"></param>
        /// <returns></returns>
        [HttpGet("order-process_repairs-detail")]
        public async Task<ProcessRepairDetailDto> GetProcessRepairDetail(Guid process_repair_id, Guid product_repair_id, Guid customer_id)
        {
            return await _processRepairAppService.GetProcessRepairDetail(process_repair_id, product_repair_id, customer_id);
        }
        /// <summary>
        /// lấy danh sách quy trình sửa chữa
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="customerTypeEnum"></param>
        /// <param name="eProcessRepairType"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        [HttpGet("order-process_repairs")]
        public async Task<ReponseDataDto<ListProcessRepairDto>> GetListProcessRepair(int page, int perPage, string filter = null, DateTime? fromDate = null,
                              DateTime? toDate = null, ECustomerTypeEnum? customerTypeEnum = null, EProcessRepairType? eProcessRepairType = null, Guid? user_id = null)
        {
            return await _orderRepairAppService.GetListProcessRepair(page, perPage, filter, fromDate, toDate, customerTypeEnum, eProcessRepairType, user_id);
        }

        /// <summary>
        /// chỉnh sửa quy trình bán hàng
        /// </summary>
        /// <param name="process_repair_id"></param>
        /// <param name="product_repair_id"></param>
        /// <param name="order_repair_id"></param>
        /// <param name="updateProcessProductRepairDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateProcessRepair(Guid process_repair_id, Guid product_repair_id, Guid order_repair_id, UpdateProcessProductRepairDto updateProcessProductRepairDto)
        {
            await _orderRepairAppService.UpdateProcessRepair(process_repair_id, product_repair_id, order_repair_id, updateProcessProductRepairDto);
        }

        /// <summary>
        /// chỉnh sửa giá
        /// </summary>
        /// <param name="product_repair_id"></param>
        /// <param name="process_repair_id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("price")]
        public async Task UpdateNewPrice(Guid product_repair_id, Guid process_repair_id, decimal input)
        {
            await _processRepairAppService.UpdateNewPrice(product_repair_id, process_repair_id, input);
        }

    }
}
