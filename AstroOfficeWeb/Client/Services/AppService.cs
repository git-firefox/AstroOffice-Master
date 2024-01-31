using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Client.Services
{
    public class AppService : IAppService
    {
        public PlatformType GetPlatformType()
        {
            return PlatformType.Web;
        }
    }
}
