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
            if (!String.IsNullOrEmpty(fileName) && (!fileName.StartsWith("data:image") && (!fileName.StartsWith("http") || !fileName.StartsWith("https"))))
            {
                fileName = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/media/" + fileName;
                StringBuilder sb = new StringBuilder(fileName);

                if (extension != null)
                {
                    sb.Append("." + extension);
                    fileName = sb.ToString();
                }
            }
            return fileName;
        }
    }
}
