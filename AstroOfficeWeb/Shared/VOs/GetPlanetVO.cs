using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class GetPlanetVO
    {
        private string _planet;

        private string _house;

        public string House
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

        public string Planet
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

        public GetPlanetVO()
        {
        }
    }
}