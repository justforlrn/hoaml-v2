using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.CashReceipt
{
    public interface ICashReceiptAppService : IApplicationService
    {
        Task<CashReceiptDto> GetAsync(Guid id);

        Task<ReponseListDataDto<CashReceiptDto>> GetListAsync(int page, int perPage, string filter);

        Task<CashReceiptDto> CreateAsync(CreateUpdateCashReceiptDto input);

        Task UpdateAsync(Guid id, CreateUpdateCashReceiptDto input);

        Task DeleteAsync(Guid id);
    }
}
