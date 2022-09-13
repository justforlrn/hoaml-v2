using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Managerment.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Cat_name { get; set; }
        public Guid Parent_Id { get; set; }
    }
}
