using System;

namespace AstroShared.Models
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