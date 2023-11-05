using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Helper
{
    public static class AvatarGenerator
    {
        public static string GenerateUserAvatar(string? username)
        {
            char firstLetter = !string.IsNullOrEmpty(username) ? username.ToUpper()[0] : 'U';

            string svg = $@"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='#007bff' /><text x='50%' y='50%' dominant-baseline='middle' text-anchor='middle' fill='white' font-size='36'>{firstLetter}</text></svg>";

            byte[] svgBytes = System.Text.Encoding.UTF8.GetBytes(svg);
            string base64Svg = Convert.ToBase64String(svgBytes);

            return "data:image/svg+xml;base64," + base64Svg;
        }
    }
}
