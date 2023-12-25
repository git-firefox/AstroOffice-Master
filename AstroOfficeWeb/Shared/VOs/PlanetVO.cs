using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class PlanetVO
    {
        private int _sno;

        private string _planetname;

        private string _planetname_hindi;

        private string _planetname_english;

        private int _pakka_ghar;

        private string _color;

        private string _karya;

        private string _samay;

        private string _din;

        private int _gender;

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public string Din
        {
            get
            {
                return _din;
            }
            set
            {
                _din = value;
            }
        }

        public int Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public string Karya
        {
            get
            {
                return _karya;
            }
            set
            {
                _karya = value;
            }
        }

        public int Pakka_ghar
        {
            get
            {
                return _pakka_ghar;
            }
            set
            {
                _pakka_ghar = value;
            }
        }

        public string Planetname
        {
            get
            {
                return _planetname;
            }
            set
            {
                _planetname = value;
            }
        }

        public string PlanetnameEnglish
        {
            get
            {
                return _planetname_english;
            }
            set
            {
                _planetname_english = value;
            }
        }

        public string PlanetnameHindi
        {
            get
            {
                return _planetname_hindi;
            }
            set
            {
                _planetname_hindi = value;
            }
        }

        public string Samay
        {
            get
            {
                return _samay;
            }
            set
            {
                _samay = value;
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

        public PlanetVO()
        {
        }
    }
}