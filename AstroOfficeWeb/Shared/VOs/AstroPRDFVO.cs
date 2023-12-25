using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class AstroPRDFVO
    {
        private int _sno;

        private int _planet;

        private int _rashi;

        private int _drishti;

        private string _hindi;

        private string _marathi;

        private string _english;

        private string _punjabi;

        public int drishti
        {
            get
            {
                return _drishti;
            }
            set
            {
                _drishti = value;
            }
        }

        public string english
        {
            get
            {
                return _english;
            }
            set
            {
                _english = value;
            }
        }

        public string marathi
        {
            get
            {
                return _marathi;
            }
            set
            {
                _marathi = value;
            }
        }

        public int planet
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

        public string pred
        {
            get
            {
                return _hindi;
            }
            set
            {
                _hindi = value;
            }
        }

        public string punjabi
        {
            get
            {
                return _punjabi;
            }
            set
            {
                _punjabi = value;
            }
        }

        public int rashi
        {
            get
            {
                return _rashi;
            }
            set
            {
                _rashi = value;
            }
        }

        public int sno
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

        public AstroPRDFVO()
        {
        }
    }
}