using Managerment.Stores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/store")]
    public class StoreController : ManagermentController
    {
        private readonly IStoreAppService _storeAppService;
        public StoreController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService;
        }
        [HttpPost]
        public async Task<StoreDto> CreateAsync([FromBody] CreateUpdateStoreDto input)
        {
            var store = await _storeAppService.CreateAsync(input);

            return store;
        }
        [HttpGet("store/{id}")]
        public async Task<StoreDto> GetAsync(Guid id)
        {
            return await _storeAppService.GetAsync(id);
        }
        [HttpGet("stores")]
        public async Task<List<StoreDto>> GetListAsync()
        {
            return await _storeAppService.GetListAsync();
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateStoreDto input)
        {
            await _storeAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _storeAppService.DeleteAsync(id);
        }
    }
}
