using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class PlanetRelationsVO
    {
        private int _sno;

        private int _planet1;

        private int _planet2;

        private int _relation;

        public int Planet1
        {
            get
            {
                return _planet1;
            }
            set
            {
                _planet1 = value;
            }
        }

        public int Planet2
        {
            get
            {
                return _planet2;
            }
            set
            {
                _planet2 = value;
            }
        }

        public int Relation
        {
            get
            {
                return _relation;
            }
            set
            {
                _relation = value;
            }
        }

        public int Sno
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

        public PlanetRelationsVO()
        {
        }
    }
}