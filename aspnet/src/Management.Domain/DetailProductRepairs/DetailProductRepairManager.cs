using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.DetailProductRepairs
{
    public class DetailProductRepairManager : DomainService
    {
        public DetailProductRepair CreateAsync(
         int pd_cpu,
         int pd_hdd,
         int pd_ram,
         int pd_wifi,
         int pd_pin,
         int pd_adapter,
         int pd_keyboard,
         int pd_psu,
         int pd_lcd,
         string text
        )
    {
        return new DetailProductRepair(
            GuidGenerator.Create(),
            pd_cpu,
            pd_hdd,
            pd_ram,
            pd_wifi,
            pd_pin,
            pd_adapter,
            pd_keyboard,
            pd_psu,
            pd_lcd,
            text
        );
    }
}
}
