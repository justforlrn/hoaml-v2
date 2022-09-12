using Managerment.PaymentHistories;
using Managerment.Shares;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/payment-histories")]
    public class PaymentHistoryController : ManagermentController
    {
        private readonly IPaymentHistoryAppService _paymentHistoryAppService;
        public PaymentHistoryController(IPaymentHistoryAppService paymentHistoryAppService)
        {
            _paymentHistoryAppService = paymentHistoryAppService;
        }
        [HttpPost]
        public async Task<PaymentHistoryDto> CreateAsync([FromBody] CreateUpdatePaymentHistoryDto input)
        {
            var product = await _paymentHistoryAppService.CreateAsync(input);

            return product;
        }
        [HttpGet("payment-history/{id}")]
        public async Task<PaymentHistoryDto> GetAsync(Guid id)
        {
            return await _paymentHistoryAppService.GetAsync(id);
        }

        [HttpGet("payment-histories")]
        public async Task<ReponseListDataDto<PaymentHistoryDto>> GetListAsync(int page, int perPage)
        {
            return await _paymentHistoryAppService.GetListAsync(page, perPage);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _paymentHistoryAppService.DeleteAsync(id);
        }
    }
}
