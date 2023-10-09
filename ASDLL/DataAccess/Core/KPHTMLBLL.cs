using System;

namespace ASDLL.DataAccess.Core
{
    public class KPHTMLBLL
    {
        public KPHTMLBLL()
        {
        }

        private string Set_Font_E(string fontname, string fontcolor, short fontsize)
        {
            return "</font>";
        }

        private string Set_Font_S(string fontname, string fontcolor, short fontsize)
        {
            string[] strArrays = new string[] { "<font face=\"", fontname, "\" color=\"", fontcolor, "\" size=\"", fontsize.ToString(), "\">" };
            return string.Concat(strArrays);
        }
    }
}