using AstroOfficeWeb.Shared.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AstroOfficeWeb.Server.Controllers
{

    public class BaseController : ControllerBase
    {
        protected string? SetMedia(string? fileName, string? extension = null)
        {
            fileName = (!String.IsNullOrEmpty(fileName) && !fileName.StartsWith("data:image")) ? HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/media/" + fileName : fileName;

            StringBuilder sb = new StringBuilder(fileName);

            if (extension != null)
            {
                sb.Append("." + extension);
                fileName = sb.ToString();

            }
            return fileName;
        }
    }
}
