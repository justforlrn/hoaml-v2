using Volo.Abp.Settings;

namespace Management.Settings;

public class ManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ManagementSettings.MySetting1));
    }
}
