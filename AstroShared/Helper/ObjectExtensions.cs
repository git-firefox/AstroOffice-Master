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
        public static string ToMobileNumber(this object? obj, string seperator)
        {
            string mobileString = obj.ToStringX().Replace(seperator, string.Empty);
            return mobileString;
        }
    }
}