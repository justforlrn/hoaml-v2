using Management;
using Managerment.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Suppliers
{
    [RemoteService(IsEnabled = false)]
    public class SupplierAppService : ManagementAppService, ISupplierAppService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierManager _supplierManager;

        public SupplierAppService(
            ISupplierRepository supplierRepository,
            SupplierManager supplierManager)
        {
            _supplierRepository = supplierRepository;
            _supplierManager = supplierManager;
        }
        public async Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input)
        {
            if (await _supplierRepository.AnyAsync(x => x.Name == input.Name))
            {
                throw new UserFriendlyException("Tên này hiện đã tồn tại");
            }
            else
            {
                try
                {
                    var cat = _supplierManager.CreateAsync(input.Name, input.Phone , input.Address, input.Email ,input.Tax, input.URL_image, input.Notes);

                    await _supplierRepository.InsertAsync(cat);

                    return ObjectMapper.Map<Supplier, SupplierDto>(cat);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _supplierRepository.DeleteAsync(id);
        }

        public async Task<SupplierDto> GetAsync(Guid id)
        {
            var product = await _supplierRepository.GetAsync(id);
            return ObjectMapper.Map<Supplier, SupplierDto>(product);
        }

        public async Task<PagedResultDto<SupplierDto>> GetListAsync(int page, int perPage, string filter)
        {
            var suppliers = await _supplierRepository.GetListAsync(page, perPage, filter);
            var totalCount = filter == null
                ? await _supplierRepository.CountAsync()
                : await _supplierRepository.CountAsync(
                    sup => sup.Name.ToLower().Trim().Contains(filter.ToLower().Trim()));

            return new PagedResultDto<SupplierDto>(
                totalCount,
                ObjectMapper.Map<List<Supplier>, List<SupplierDto>>(suppliers)
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateSupplierDto input)
        {
            var sup = await _supplierRepository.GetAsync(id);

            sup.Name = input.Name;
            sup.Phone = input.Phone;
            sup.Address = input.Address;
            sup.Email = input.Email;
            sup.Tax = input.Tax;
            sup.URL_image = input.URL_image;
            sup.Notes = input.Notes;

            await _supplierRepository.UpdateAsync(sup);
        }
    }
}
