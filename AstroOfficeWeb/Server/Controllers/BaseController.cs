using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected static string GetFileExtension(string url)
        {
            // Extract the file extension from the URL
            return url.Substring(url.LastIndexOf('.') + 1).ToLower();
        }

        protected static string GetMimeType(string fileExtension)
        {
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

        protected string? SetMedia(string? fileName, string? extension = null, bool returnDataUrl = false)
        {
            string? fileUrl = null;
            if (returnDataUrl)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", $"{fileName}.{extension?.ToLower()}");
                if (System.IO.File.Exists(filePath))
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                    fileUrl = $"data:{GetMimeType(GetFileExtension(filePath))};base64,{Convert.ToBase64String(fileBytes)}";
                }
            }
            else (!String.IsNullOrEmpty(fileName) && (!fileName.StartsWith("data:image") && (!fileName.StartsWith("http") || !fileName.StartsWith("https"))))
            {
                fileUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/media/" + fileName;
                var sb = new StringBuilder(fileUrl);

                if (extension != null)
                {
                    sb.Append("." + extension);
                    fileUrl = sb.ToString();
                }
            }

            //if (returnDataUrl)
            //{
            //    using (var client = new HttpClient())
            //    {
            //        byte[] imageBytes = client.GetByteArrayAsync(fileName).Result;
            //        string base64String = Convert.ToBase64String(imageBytes);
            //        string dataUri = $"data:{GetMimeType(GetFileExtension(fileName))};base64,{base64String}";
            //        return dataUri;
            //    }
            //}
            return fileUrl;
        }
    }
}
