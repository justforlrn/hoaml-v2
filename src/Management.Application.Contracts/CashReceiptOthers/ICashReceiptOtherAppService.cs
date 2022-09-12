using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Managerment.CashReceiptOthers
{
    public interface ICashReceiptOtherAppService : IApplicationService
    {
        Task<CashReceiptOtherDto> GetAsync(Guid id);

        Task<ReponseListDataDto<CashReceiptOtherDto>> GetListAsync(int page, int perPage, string filter);

        Task<CashReceiptOtherDto> CreateAsync(CreateUpdateCashReceiptOtherDto input);

        Task UpdateAsync(Guid id, CreateUpdateCashReceiptOtherDto input);

        Task DeleteAsync(Guid id);
    }
}
