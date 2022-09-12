using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.PaymentHistories
{
    public interface IPaymentHistoryAppService : IApplicationService
    {
        Task<PaymentHistoryDto> GetAsync(Guid id);

        Task<ReponseListDataDto<PaymentHistoryDto>> GetListAsync(int skip, int take);

        Task<PaymentHistoryDto> CreateAsync(CreateUpdatePaymentHistoryDto input);

        Task DeleteAsync(Guid id);
    }
}
