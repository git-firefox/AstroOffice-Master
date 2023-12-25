using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class CityVO
    {
        private long _sno;

        private long _ccode;

        private string _cityname;

        private string _longitude;

        private string _latitude;

        public long Ccode
        {
            get
            {
                return _ccode;
            }
            set
            {
                _ccode = value;
            }
        }

        public string Cityname
        {
            get
            {
                return _cityname;
            }
            set
            {
                _cityname = value;
            }
        }

        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
            }
        }

        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
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

        public CityVO()
        {
        }
    }
}