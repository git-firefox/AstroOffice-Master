using AstroOfficeWeb.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Services.IServices
{
    public interface IAppService
    {
        public PlatformType GetPlatformType();
    }
}
