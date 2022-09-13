using Management;
using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Managerment.PaymentMethods
{
    [RemoteService(IsEnabled = false)]
    public class PaymentMethodAppService : ManagementAppService, IPaymentMethodAppService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly PaymentMethodManager _paymentMethodManager;

        public PaymentMethodAppService(
            IPaymentMethodRepository paymentMethodRepository,
            PaymentMethodManager paymentMethodManager)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _paymentMethodManager = paymentMethodManager;
        }
        public async Task<PaymentMethodDto> CreateAsync(CreateUpdatePaymentMethodDto input)
        {
            if (await _paymentMethodRepository.AnyAsync(x => x.Methods == input.Methods))
            {
                throw new UserFriendlyException("Phương thức đã tồn tại!! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {

                    var paymentMethod = _paymentMethodManager.CreateAsync(input.Methods);

                    await _paymentMethodRepository.InsertAsync(paymentMethod);

                    return ObjectMapper.Map<PaymentMethod, PaymentMethodDto>(paymentMethod);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _paymentMethodRepository.DeleteAsync(id);
        }

        public async Task<PaymentMethodDto> GetAsync(Guid id)
        {
            var paymentMethod = await _paymentMethodRepository.GetAsync(id);
            return ObjectMapper.Map<PaymentMethod, PaymentMethodDto>(paymentMethod);
        }

        public async Task<ReponseListDataDto<PaymentMethodDto>> GetListAsync(int page, int perPage)
        {
            var paymentMethods = await _paymentMethodRepository.GetListAsync(page, perPage);

            var storesMap = ObjectMapper.Map<List<PaymentMethod>, List<PaymentMethodDto>>(paymentMethods.Item2);

            int pageCout = paymentMethods.Item1 == 0 ? 0 : paymentMethods.Item1 / perPage + 1;

            return new ReponseListDataDto<PaymentMethodDto>()
            {
                Count = paymentMethods.Item1,
                Page = page,
                Per_page = perPage,
                Total_pages = pageCout,
                Data = storesMap
            };
        }

        public async Task UpdateAsync(Guid id, CreateUpdatePaymentMethodDto input)
        {
            var paymentMethod = await _paymentMethodRepository.GetAsync(id);

            paymentMethod.Methods = input.Methods;

            await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }
    }
}
