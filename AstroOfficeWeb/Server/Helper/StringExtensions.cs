using System.Net;

namespace AstroOfficeWeb.Server.Helper
{
    public static class StringExtensions
    {
        public static string ToUrlEncode(this string str)
        {
            string encodedString = WebUtility.UrlEncode(str);
            return encodedString;
        }
    }
}
