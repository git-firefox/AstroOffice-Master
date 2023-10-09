using System;

namespace AstroShared.Models
{
    public class AstroPHFVO
    {
        private int _sno;

        private int _planet;

        private int _house;

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

        public int house
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

        public AstroPHFVO()
        {
        }
    }
}