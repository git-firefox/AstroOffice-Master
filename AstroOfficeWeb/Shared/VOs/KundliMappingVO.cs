using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KundliMappingVO
    {
        private long _sno;

        private int _house;

        private int _rashi;

        private int _planet;

        private string _planetname;

        private string _planetnamehindi;

        private string _planetnameenglish;

        private string _deg;

        private long _kundliid;

        private bool _pakke;

        private bool _mande;

        private bool _neech;

        private bool _uch;

        private bool _shresht;

        private bool _soya;

        private bool _kayam;

        private bool _isbad;

        private bool _visbad;

        public string Degree
        {
            get
            {
                return _deg;
            }
            set
            {
                _deg = value;
            }
        }

        public int House
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

        public bool IsBad
        {
            get
            {
                return _isbad;
            }
            set
            {
                _isbad = value;
            }
        }

        public bool Kayam
        {
            get
            {
                return _kayam;
            }
            set
            {
                _kayam = value;
            }
        }

        public long Kundliid
        {
            get
            {
                return _kundliid;
            }
            set
            {
                _kundliid = value;
            }
        }

        public bool Mande
        {
            get
            {
                return _mande;
            }
            set
            {
                _mande = value;
            }
        }

        public bool Neech
        {
            get
            {
                return _neech;
            }
            set
            {
                _neech = value;
            }
        }

        public bool Pakke
        {
            get
            {
                return _pakke;
            }
            set
            {
                _pakke = value;
            }
        }

        public int Planet
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

        public string PlanetName
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

        public string PlanetNameEnglish
        {
            get
            {
                return _planetnameenglish;
            }
            set
            {
                _planetnameenglish = value;
            }
        }

        public string PlanetNameHindi
        {
            get
            {
                return _planetnamehindi;
            }
            set
            {
                _planetnamehindi = value;
            }
        }

        public int Rashi
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

        public bool Shresht
        {
            get
            {
                return _shresht;
            }
            set
            {
                _shresht = value;
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

        public bool Soya
        {
            get
            {
                return _soya;
            }
            set
            {
                _soya = value;
            }
        }

        public bool Uch
        {
            get
            {
                return _uch;
            }
            set
            {
                _uch = value;
            }
        }

        public bool VIsBad
        {
            get
            {
                return _visbad;
            }
            set
            {
                _visbad = value;
            }
        }

        public KundliMappingVO()
        {
        }
    }
}