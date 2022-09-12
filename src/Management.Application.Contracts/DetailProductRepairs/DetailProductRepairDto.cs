using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.DetailProductRepairs
{
    public class DetailProductRepairDto : EntityDto<Guid>
    {
        public int PD_CPU { get; set; }
        public int PD_HDD { get; set; }
        public int PD_Ram { get; set; }
        public int PD_Wifi { get; set; }
        public int PD_Pin { get; set; }
        public int PD_Adapter { get; set; }
        public int PD_Keyboard { get; set; }
        public int PD_PSU { get; set; }
        public int PD_LCD { get; set; }
        public string Text { get; set; }
    }
}
