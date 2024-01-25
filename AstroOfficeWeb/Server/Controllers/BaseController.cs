using AstroOfficeWeb.Shared.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AstroOfficeWeb.Server.Controllers
{

    public class BaseController : ControllerBase
    {


        public static string GetFileExtension(string url)
        {
            // Extract the file extension from the URL
            return url.Substring(url.LastIndexOf('.') + 1).ToLower();
        }

        public static string GetMimeType(string fileExtension)
        {
            // Map file extension to MIME type (adjust as needed)
            switch (fileExtension)
            {
                case "jpg":
                case "jpeg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                case "gif":
                    return "image/gif";
                case "mp4":
                    return "video/mp4";
                case "webm":
                    return "video/webm";
                default:
                    return "application/octet-stream";
            }
        }

        protected string? SetMedia(string? fileName, string? extension = null, bool isDataUrl = false)
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

                if (isDataUrl)
                {
                    using (var client = new HttpClient())
                    {
                        byte[] imageBytes = client.GetByteArrayAsync(fileName).Result;
                        string base64String = Convert.ToBase64String(imageBytes);
                        string dataUri = $"data:{GetMimeType(GetFileExtension(fileName))};base64,{base64String}";
                       return dataUri;
                    }
                }
            }
            return fileName;
        }
    }
}
