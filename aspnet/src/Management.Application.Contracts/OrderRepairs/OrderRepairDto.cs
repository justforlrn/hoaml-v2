using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.OrderRepairs
{
    public class OrderRepairDto : EntityDto<Guid>
    {
        public string OR_code { get; set; }
        public string Text { get; set; }
        public Guid ID_cus { get; set; }
        public Guid ID_user { get; set; }
    }
}
