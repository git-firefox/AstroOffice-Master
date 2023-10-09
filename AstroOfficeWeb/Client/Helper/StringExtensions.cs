namespace AstroOfficeWeb.Client.Helper
{
    public static class StringExtensions
    {
        public static string Longi2Timezone(this string full_tz)
        {
            string str;
            if (full_tz.IndexOf(':') <= 0)
            {
                str = full_tz.Substring(0, full_tz.Length - 1).ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = Convert.ToDouble(str).DecimalToDMS();
                str = str.Replace(":", ".");
                if (str.Length == 4)
                {
                    str = string.Concat("0", str);
                }
            }
            else
            {
                string str1 = full_tz.Substring(0, full_tz.Length - 1).ToString();
                char[] chrArray = new char[] { ':' };
                string[] strArrays = str1.Split(chrArray);
                double num = DoubleExtensions.DMStoDecimal(Convert.ToDouble(strArrays[0]), Convert.ToDouble(strArrays[1]), 0);
                str = num.ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = DoubleExtensions.DecimalToDMS(Convert.ToDouble(str)).ToString();
                chrArray = new char[] { ':' };
                strArrays = str.Split(chrArray);
                if (strArrays[0].Length == 1)
                {
                    strArrays[0] = string.Concat("0", strArrays[0]);
                }
                str = string.Concat(strArrays[0], ".", strArrays[1]);
            }
            str = (!(full_tz.Substring(full_tz.Length - 1, 1).ToString() == "E") ? string.Concat("-", str) : string.Concat("+", str));
            return str;
        }
    }
}
