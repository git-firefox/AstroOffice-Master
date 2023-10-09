using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOffice.Helper
{
    internal static class BitmapExtensions
    {
        public static string ToString_PNG(this Bitmap bitmap)
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
