using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class TimeZoneVO
    {
        private double _tz;

        private string _countryname;

        public string CountryName
        {
            get
            {
                return _countryname;
            }
            set
            {
                _countryname = value;
            }
        }

        public double TimeZone
        {
            get
            {
                return _tz;
            }
            set
            {
                _tz = value;
            }
        }

        public TimeZoneVO()
        {
        }
    }
}