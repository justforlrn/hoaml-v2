using Volo.Abp.Modularity;

namespace Management;

[DependsOn(
    typeof(ManagementApplicationModule),
    typeof(ManagementDomainTestModule)
    )]
public class ManagementApplicationTestModule : AbpModule
{

}
