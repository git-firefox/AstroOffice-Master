namespace AstroOfficeWeb.Client.Helper
{
    public static class LongExtensions
    {
        public static string Get_Duration_String(this long days)
        {
            string str = "";
            long num = (long)0;
            long num1 = (long)0;
            long num2 = (long)0;
            num = Convert.ToInt64(Convert.ToInt64(Math.Floor((double)days / 30.41)) / (long)12);
            num1 = Convert.ToInt64(Convert.ToInt64(Math.Floor((double)days / 30.41)) - num * (long)12);
            num2 = Convert.ToInt64(days - num * (long)365);
            num2 = Convert.ToInt64((double)num2 - (double)num1 * 30.41);
            if ((num2 == (long)30 ? true : num2 == (long)31))
            {
                num1 = Convert.ToInt64(num1 + (long)1);
                num2 = (long)0;
            }
            if (num > (long)0)
            {
                str = string.Concat(str, "Y", num.ToString());
            }
            if (num1 > (long)0)
            {
                str = string.Concat(str, " M", num1.ToString());
            }
            str = string.Concat(str, " D", num2.ToString());
            str = str.TrimStart(new char[] { ' ' });
            return str;
        }
    }
}
