using System;

namespace AstroShared.Models
{
    public class RashiDetailsVO
    {
        private int _sno;

        private int _rcode;

        private string _relative;

        private string _quality;

        private string _work;

        private string _bodypart;

        private string _place;

        private string _things;

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

        public int Rcode
        {
            get
            {
                return _rcode;
            }
            set
            {
                _rcode = value;
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

        public string Work
        {
            get
            {
                return _work;
            }
            set
            {
                _work = value;
            }
        }

        public RashiDetailsVO()
        {
        }
    }
}