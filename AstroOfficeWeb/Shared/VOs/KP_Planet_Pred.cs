using System;
using System.Runtime.CompilerServices;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KP_Planet_Pred
    {
        public short House
        {
            get;
            set;
        }

        public short Planet
        {
            get;
            set;
        }

        public string Pred_Hindi
        {
            get;
            set;
        }

        public long Sno
        {
            get;
            set;
        }

        public KP_Planet_Pred()
        {
        }
    }
}