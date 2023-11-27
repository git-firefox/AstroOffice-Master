using System.Text.RegularExpressions;

namespace AstroShared.Helper
{
    public static class ObjectExtensions
    {
        public static string ToStringLower(this object? obj)
        {
            return obj != null ? obj.ToString()!.Trim().ToLower() : string.Empty;
        }
        public static string ToStringX(this object? obj)
        {
            return obj != null ? obj.ToString()!.Trim() : string.Empty;
        }

        public static string? ToMobileNumber(this object? obj)
        {
            string? objString = obj?.ToString();
            if (!string.IsNullOrEmpty(objString))
            {
                objString = Regex.Replace(objString, @"\D", "");
                objString = objString.Substring(0, Math.Min(objString.Length, 10));
                return objString;
            }
            return null;
        }

        public static string? ToDigits(this object? obj)
        {
            string? objString = obj?.ToString();
            if (!string.IsNullOrEmpty(objString))
            {
                objString = Regex.Replace(objString, @"\D", "");
                objString = objString.Substring(0, Math.Min(objString.Length, 10));
                return objString;
            }
            return string.Empty;
        }
    }
}