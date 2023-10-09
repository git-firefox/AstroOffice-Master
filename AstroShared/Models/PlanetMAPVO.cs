using System;

namespace AstroShared.Models
{
    public class PlanetMAPVO
    {
        private long _newastro;

        private long _mangal;

        public long Mangal
        {
            get
            {
                return _mangal;
            }
            set
            {
                _mangal = value;
            }
        }

        public long NewAstro
        {
            get
            {
                return _newastro;
            }
            set
            {
                _newastro = value;
            }
        }

        public PlanetMAPVO()
        {
        }
    }
}