using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Shares
{
    public class ReponseListDataDto<T>
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total_pages { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
