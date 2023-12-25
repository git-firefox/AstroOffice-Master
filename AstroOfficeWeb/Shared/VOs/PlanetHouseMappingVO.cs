using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class PlanetHouseMappingVO
    {
        private long _sno;

        private int _planet;

        private int _house;

        public int House
        {
            get
            {
                return _house;
            }
            set
            {
                _house = value;
            }
        }

        public int Planet
        {
            get
            {
                return _planet;
            }
            set
            {
                _planet = value;
            }
        }

        public long Sno
        {
            get
            {
                return _sno;
            }
            set
            {
                _sno = value;
            }
        }

        public PlanetHouseMappingVO()
        {
        }
    }
}