using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class AstroLFVO
    {
        private int _sno;

        private int _lagna;

        private string _hindi;

        private string _marathi;

        private string _english;

        private string _punjabi;

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

        public int lagna
        {
            get
            {
                return _lagna;
            }
            set
            {
                _lagna = value;
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

        public AstroLFVO()
        {
        }
    }
}