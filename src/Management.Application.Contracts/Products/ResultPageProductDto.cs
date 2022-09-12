using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Products
{
    public class ResultPageProductDto
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total_pages { get; set; }
        public int Count { get; set; }
        public List<ListProductDto> Data { get; set; }
    }
}
