using Management.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Managerment.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ManagermentController : AbpControllerBase
{
    protected ManagermentController()
    {
        LocalizationResource = typeof(ManagementResource);
    }
}
