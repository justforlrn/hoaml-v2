using Management.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Management;

[DependsOn(
    typeof(ManagementEntityFrameworkCoreTestModule)
    )]
public class ManagementDomainTestModule : AbpModule
{

}
