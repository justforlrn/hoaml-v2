using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.CustomCodes
{
    public class CustomCodeManager : DomainService
    {
        public CustomCode CreateAsync(
            [NotNull] string codeName,
            [NotNull] string codeValue
          )
        {
            return new CustomCode(
                GuidGenerator.Create(),
                codeName,
                codeValue
            );
        }
    }
}
