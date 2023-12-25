using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class CountryVO
    {
        private long _sno;

        private string _countryname;

        public string Countryname
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

        public CountryVO()
        {
        }
    }
}