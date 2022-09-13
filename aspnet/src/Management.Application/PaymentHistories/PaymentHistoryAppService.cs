using Management;
using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.PaymentHistories
{
    [RemoteService(IsEnabled = false)]
    public class PaymentHistoryAppService : ManagementAppService, IPaymentHistoryAppService
    {
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;
        private readonly PaymentHistoryManager _paymentHistoryManager;

        public PaymentHistoryAppService(
            IPaymentHistoryRepository paymentHistoryRepository,
            PaymentHistoryManager paymentHistoryManager)
        {
            _paymentHistoryRepository = paymentHistoryRepository;
            _paymentHistoryManager = paymentHistoryManager;
        }
        public async Task<PaymentHistoryDto> CreateAsync(CreateUpdatePaymentHistoryDto input)
        {
                    var payment = _paymentHistoryManager.CreateAsync(input.Date_pay, input.Money, input.ID_payment);

                    await _paymentHistoryRepository.InsertAsync(payment);

                    return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(payment);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _paymentHistoryRepository.DeleteAsync(id);
        }

        public async Task<PaymentHistoryDto> GetAsync(Guid id)
        {
            var payment = await _paymentHistoryRepository.GetAsync(id);
            return ObjectMapper.Map<PaymentHistory, PaymentHistoryDto>(payment);
        }

        public async Task<ReponseListDataDto<PaymentHistoryDto>> GetListAsync(int page, int perPage)
        {
            var payments = await _paymentHistoryRepository.GetListAsync(page, perPage);

            var storesMap = ObjectMapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(payments.Item2);

            int pageCout = payments.Item1 == 0 ? 0 : payments.Item1 / perPage + 1;

            return new ReponseListDataDto<PaymentHistoryDto>()
            {
                Count = payments.Item1,
                Page = page,
                Per_page = perPage,
                Total_pages = pageCout,
                Data = storesMap
            };
        }
    }
}
