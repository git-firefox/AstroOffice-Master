using System;

namespace AstroShared.Models
{
    public class KPSigniVO
    {
        private short _rule;

        private short _signi;

        private short _whichplanet;

        public short Rule
        {
            get
            {
                return _rule;
            }
            set
            {
                _rule = value;
            }
        }

        public short Signi
        {
            get
            {
                return _signi;
            }
            set
            {
                _signi = value;
            }
        }

        public short WhichPlanet
        {
            get
            {
                return _whichplanet;
            }
            set
            {
                _whichplanet = value;
            }
        }

        public KPSigniVO()
        {
        }
    }
}