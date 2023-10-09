using System.Drawing;
using System.Runtime.Versioning;

namespace AstroOfficeWeb.Server.Helper
{
    public static class BitmapExtensions
    {
        [SupportedOSPlatform("windows")]
        public static string ToBase64String(this Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                string base64Image = Convert.ToBase64String(imageBytes);
                return $"data:image/png;base64,{base64Image}";
            }
        }
    }
}
