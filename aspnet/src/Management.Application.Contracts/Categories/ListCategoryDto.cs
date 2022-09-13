using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Categories
{
    public class ListCategoryDto
    {
        public Guid Id { get; set; }
        public string Cat_name { get; set; }
        public Guid Parent_Id { get; set; }
        public List<CategoryDto> CategoryParents { get; set; }
    }
}
