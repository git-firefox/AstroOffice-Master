using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Helper
{
    public static class StringExtensions
    {
        public static string ToUrlEncode(this string str)
        {
            string encodedString = WebUtility.UrlEncode(str);
            return encodedString;
        }

        public static string ToUrlFriendlyString(this string @string)
        {
            return @string.Replace(" ", "-").ToLower();
        }
    }
}
