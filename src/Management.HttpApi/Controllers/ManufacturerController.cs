using Managerment.Manufacturers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Managerment.Controllers
{
    [Route("api/manufacturers")]
    public class ManufacturerController : ManagermentController
    {
        private readonly IManufacturerAppService _manufacturerAppService;
        public ManufacturerController(IManufacturerAppService manufacturerAppService)
        {
            _manufacturerAppService = manufacturerAppService;
        }
        [HttpPost]
        public async Task<ManufacturerDto> CreateAsync([FromBody]CreateUpdateManufacturerDto input)
        {
            var manufacturer = await _manufacturerAppService.CreateAsync(input);

            return manufacturer;
        }
        [HttpGet("manufacturer/{id}")]
        public async Task<ManufacturerDto> GetAsync(Guid id)
        {
            return await _manufacturerAppService.GetAsync(id);
        }
        [HttpGet("manufacturers")]
        public async Task<PagedResultDto<ManufacturerDto>> GetListAsync(int page, int perPage, string filter)
        {
            return await _manufacturerAppService.GetListAsync(page, perPage, filter);
        }
        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateManufacturerDto input)
        {
            await _manufacturerAppService.UpdateAsync(id, input);
        }
        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _manufacturerAppService.DeleteAsync(id);
        }
    }
}
