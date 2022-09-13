using Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.CustomCodes
{
    [RemoteService(IsEnabled = true)]
    public class CustomCodeAppService : ManagementAppService
    {
        private readonly ICustomCodeRepository _customCodeRepository;
        private readonly CustomCodeManager _customCodeManager;

        public CustomCodeAppService(
            ICustomCodeRepository customCodeRepository,
            CustomCodeManager customCodeManager)
        {
            _customCodeRepository = customCodeRepository;
            _customCodeManager = customCodeManager;
        }
        public async Task CreateAsync(CreateCustomCodeDto input)
        {
            var code = _customCodeManager.CreateAsync(input.CodeName, input.CodeValue);
            await _customCodeRepository.InsertAsync(code);
        }
        public async Task UpdateAsync(string codeName)
        {
            var code = await _customCodeRepository.GetAsync(x => x.CodeName == codeName);

            code.CodeValue = (Int32.Parse(code.CodeValue) + 1).ToString();

            await _customCodeRepository.UpdateAsync(code);
        }
        public async Task<string> GenerateCode(string codeName)
        {
            var customCode = await _customCodeRepository.GetAsync(x => x.CodeName == codeName);

            var value = Int32.Parse(customCode.CodeValue);

            string result = "";
            switch (value)
            {
                case < 10:
                    result = codeName + "00000" + value;
                    return result;
                case < 100:
                    result = codeName + "0000" + value;
                    return result;
                case < 1000:
                    result = codeName + "000" + value;
                    return result;
                case < 10000:
                    result = codeName + "00" + value;
                    return result;
                case < 100000:
                    result = codeName + "0" + value;
                    return result;
                case < 1000000:
                    result = codeName + value;
                    return result;
            }
            return result;
        }
    }
}
