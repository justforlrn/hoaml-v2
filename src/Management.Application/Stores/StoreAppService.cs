using Management;
using Managerment.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Stores
{
    [RemoteService(IsEnabled = false)]
    public class StoreAppService : ManagementAppService, IStoreAppService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly StoreManager _storeManager;

        public StoreAppService(
            IStoreRepository storeRepository,
            StoreManager storeManager)
        {
            _storeRepository = storeRepository;
            _storeManager = storeManager;
        }
        public async Task<StoreDto> CreateAsync(CreateUpdateStoreDto input)
        {
            if (await _storeRepository.AnyAsync(x => x.Store_name == input.Store_name))
            {
                throw new UserFriendlyException("Tên đã tồn tại !! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {

                    var store = _storeManager.CreateAsync(input.Store_name, input.Store_phone, input.Store_address, input.Store_imgURL);

                    await _storeRepository.InsertAsync(store);


                    return ObjectMapper.Map<Store, StoreDto>(store);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _storeRepository.DeleteAsync(id);
        }

        public async Task<StoreDto> GetAsync(Guid id)
        {
            var store = await _storeRepository.GetAsync(id);
            return ObjectMapper.Map<Store, StoreDto>(store);
        }

        public async Task<List<StoreDto>> GetListAsync()
        {
            var stores = await _storeRepository.GetListAsync();

            return ObjectMapper.Map<List<Store>, List<StoreDto>>(stores);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateStoreDto input)
        {
            var store = await _storeRepository.GetAsync(id);

            store.Store_address = input.Store_address;
            store.Store_imgURL = input.Store_imgURL;
            store.Store_name = input.Store_name;
            store.Store_phone = input.Store_phone;

            await _storeRepository.UpdateAsync(store);
        }
    }
}
