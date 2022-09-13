using Managerment.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managerment.Controllers
{
    [Route("api/enums")]
    public class EnumController : ManagermentController
    {
        public EnumController()
        {
        }
        //[HttpGet("Get-List-Profile-Type")]
        //public List<object> GetListProfileType()
        //{
        //    return _enumAppService.GetListProfileType();
        //}

        /// <summary>
        /// Loại khách hàng : 0 - khách lẻ , 1 - khách sỉ
        /// </summary>
        /// <returns></returns>
        [HttpGet("Customers_type")]
        public List<object> GetListType()
        {
            return EnumAppService.GetListCustomerType();
        }

        /// <summary>
        /// Loại sửa chữa : 0 - Chậm , 1 - Bình thường , 2 - Nhanh
        /// </summary>
        /// <returns></returns>
        [HttpGet("Product_repair_type")]
        public List<object> Product_repair_type()
        {
            return EnumAppService.GetListTypeRepair();
        }
    }
}
