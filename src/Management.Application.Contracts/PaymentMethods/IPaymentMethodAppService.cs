using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Managerment.PaymentMethods
{
    public interface IPaymentMethodAppService : IApplicationService
    {
        Task<PaymentMethodDto> GetAsync(Guid id);

        Task<ReponseListDataDto<PaymentMethodDto>> GetListAsync(int page, int perPage);

        Task<PaymentMethodDto> CreateAsync(CreateUpdatePaymentMethodDto input);

        Task UpdateAsync(Guid id, CreateUpdatePaymentMethodDto input);

        Task DeleteAsync(Guid id);
    }
}
