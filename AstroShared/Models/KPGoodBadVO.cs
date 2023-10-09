using System;
using System.Runtime.CompilerServices;

namespace AstroShared.Models
{
    public class KPGoodBadVO
    {
        public short house
        {
            get;
            set;
        }

        public bool isbad
        {
            get;
            set;
        }

        public short planet
        {
            get;
            set;
        }

        public short sno
        {
            get;
            set;
        }

        public KPGoodBadVO()
        {
        }
    }
}