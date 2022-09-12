using Management;
using Managerment.CustomerTypes;
using Managerment.ProductRepairTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Managerment.Enums
{
    public class EnumAppService : ManagementAppService
    {
        public EnumAppService()
        {

        }

        public static List<object> GetListEnums<T>() where T : Enum
        {
            List<object> list = new() { };
            var listOfEnums = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            foreach (var enumValue in listOfEnums)
            {
                list.Add(Enum.GetName(typeof(T), enumValue));
            }
            return list;
        }

        public static string GetNameEnum<T>(object value) where T : System.Enum
        {
            return Enum.GetName(typeof(T), value);
        }
        public static List<object> GetListCustomerType()
        {
            return GetListEnums<ECustomerTypeEnum>();
        }
        public static List<object> GetListTypeRepair()
        {
            return GetListEnums<EProductRepairTypeEnum>();
        }
    }
}
