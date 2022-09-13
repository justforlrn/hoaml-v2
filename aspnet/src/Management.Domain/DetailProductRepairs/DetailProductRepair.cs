using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Managerment.DetailProductRepairs
{
    public class DetailProductRepair : AuditedAggregateRoot<Guid>
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
        private DetailProductRepair()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal DetailProductRepair(
         Guid id,
         int cpu,
         int hdd,
         int ram,
         int wifi,
         int pin,
         int adapter,
         int keyboard,
         int psu,
         int lcd,
         string text
     )
     : base(id)
        {
            PD_CPU = cpu;
            PD_HDD = hdd;
            PD_Ram = ram;
            PD_Wifi = wifi;
            PD_Pin = pin;
            PD_Adapter = adapter;
            PD_Keyboard = keyboard;
            PD_PSU = psu;
            PD_LCD = lcd;
            Text = text;
        }
    }
}
