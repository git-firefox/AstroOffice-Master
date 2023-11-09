using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeMobile.Methods
{
    public class KundliBLL
    {
        public string longi2timezone(string full_tz)
        {
            string str;
            if (full_tz.IndexOf(':') <= 0)
            {
                str = full_tz.Substring(0, full_tz.Length - 1).ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = DecimalToDMS(Convert.ToDouble(str)).ToString();
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
                double num = DMStoDecimal(Convert.ToDouble(strArrays[0]), Convert.ToDouble(strArrays[1]), 0);
                str = num.ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = DecimalToDMS(Convert.ToDouble(str)).ToString();
                chrArray = new char[] { ':' };
                strArrays = str.Split(chrArray);
                if (strArrays[0].Length == 1)
                {
                    strArrays[0] = string.Concat("0", strArrays[0]);
                }
                str = string.Concat(strArrays[0], ".", strArrays[1]);
            }
            str = !(full_tz.Substring(full_tz.Length - 1, 1).ToString() == "E") ? string.Concat("-", str) : string.Concat("+", str);
            return str;
        }

        public double DMStoDecimal(double degrees, double minutes, double seconds)
        {
            double num = degrees + minutes / 60 + seconds / 3600;
            return num;
        }

        public string DecimalToDMS(double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2);
            return str;
        }

        public string Dasha_DecimalToDMS(double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2);
            str = num.ToString().Length != 1 ? string.Concat(str, ":", num) : string.Concat(str, ":0", num);
            return str;
        }
    }
}
