using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.CustomCodes
{
    public class CustomCode : AuditedAggregateRoot<Guid>
    {
        public string CodeName { get; set; }
        public string CodeValue { get; set; }
        internal CustomCode(
            Guid id,
           string codeName,
           string codeValue) : base(id)
        {
            CodeName = codeName;
            CodeValue = codeValue;
        }
    }
}
