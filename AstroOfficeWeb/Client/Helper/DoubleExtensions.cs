namespace AstroOfficeWeb.Client.Helper
{
    public static class DoubleExtensions
    {
        public static string Dasha_DecimalToDMS(this double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = (num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2));
            str = (num.ToString().Length != 1 ? string.Concat(str, ":", num) : string.Concat(str, ":0", num));
            return str;
        }

        public static string DecimalToDMS(this double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = (num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2));
            return str;
        }

        public static double DMStoDecimal(double degrees, double minutes, double seconds)
        {
            double num = degrees + minutes / 60 + seconds / 3600;
            return num;
        }
    }
}
