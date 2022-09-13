using System;
using System.Collections.Generic;
using System.Text;

namespace Managerment.Categories
{
    public class CreateUpdateCategoryDto
    {
        public string Cat_name { get; set; }
        public Guid Parent_Id { get; set; }
    }
}
