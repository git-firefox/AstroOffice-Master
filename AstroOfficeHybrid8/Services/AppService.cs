using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeHybrid8.Services
{
    internal class AppService : IAppService
    {
        public PlatformType GetPlatformType()
        {
            if(DeviceInfo.Current.Platform == DevicePlatform.Android || DeviceInfo.Current.Platform == DevicePlatform.iOS)
            {
                return PlatformType.Mobile;
            }
            else
            {
                return PlatformType.Windows;
            }
        }
    }
}
