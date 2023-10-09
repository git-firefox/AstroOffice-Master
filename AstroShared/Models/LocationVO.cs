using System;

namespace AstroShared.Models
{
    public class LocationVO
    {
        private CountryVO _country;

        public CountryVO Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        public LocationVO()
        {
        }
    }
}