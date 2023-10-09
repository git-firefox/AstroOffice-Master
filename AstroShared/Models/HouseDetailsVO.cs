using System;

namespace AstroShared.Models
{
    public class HouseDetailsVO
    {
        private int _sno;

        private int _hcode;

        private string _quality;

        private string _power;

        private string _home;

        private string _things;

        private string _direction;

        private string _animal;

        private string _relative;

        private string _plants;

        private string _place;

        private string _bodypart;

        public string Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                _animal = value;
            }
        }

        public string BodyPart
        {
            get
            {
                return _bodypart;
            }
            set
            {
                _bodypart = value;
            }
        }

        public string Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public int Hcode
        {
            get
            {
                return _hcode;
            }
            set
            {
                _hcode = value;
            }
        }

        public string Home
        {
            get
            {
                return _home;
            }
            set
            {
                _home = value;
            }
        }

        public string Place
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
            }
        }

        public string Plants
        {
            get
            {
                return _plants;
            }
            set
            {
                _plants = value;
            }
        }

        public string Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
            }
        }

        public string Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                _quality = value;
            }
        }

        public string Relative
        {
            get
            {
                return _relative;
            }
            set
            {
                _relative = value;
            }
        }

        public int Sno
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

        public string Things
        {
            get
            {
                return _things;
            }
            set
            {
                _things = value;
            }
        }

        public HouseDetailsVO()
        {
        }
    }
}