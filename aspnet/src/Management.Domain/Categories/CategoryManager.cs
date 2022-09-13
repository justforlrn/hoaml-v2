using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Managerment.Categories
{
    public class CategoryManager : DomainService
    {
        public Category CreateAsync(
            [NotNull]string cat_name,
            Guid parent_Id
          )
        {
            return new Category(
                GuidGenerator.Create(),
                cat_name,
                parent_Id
            );
        }
    }
}
