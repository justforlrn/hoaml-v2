using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Stores
{
    public class StoreDto : EntityDto<Guid>
    {
        public string Store_name { get; set; }
        public string Store_phone { get; set; }
        public string Store_address { get; set; }
        public string Store_imgURL { get; set; }
    }
}
