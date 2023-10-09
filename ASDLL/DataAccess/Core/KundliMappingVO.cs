using System;

namespace ASDLL.DataAccess.Core
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
                return this._deg;
            }
            set
            {
                this._deg = value;
            }
        }

        public int House
        {
            get
            {
                return this._house;
            }
            set
            {
                this._house = value;
            }
        }

        public bool IsBad
        {
            get
            {
                return this._isbad;
            }
            set
            {
                this._isbad = value;
            }
        }

        public bool Kayam
        {
            get
            {
                return this._kayam;
            }
            set
            {
                this._kayam = value;
            }
        }

        public long Kundliid
        {
            get
            {
                return this._kundliid;
            }
            set
            {
                this._kundliid = value;
            }
        }

        public bool Mande
        {
            get
            {
                return this._mande;
            }
            set
            {
                this._mande = value;
            }
        }

        public bool Neech
        {
            get
            {
                return this._neech;
            }
            set
            {
                this._neech = value;
            }
        }

        public bool Pakke
        {
            get
            {
                return this._pakke;
            }
            set
            {
                this._pakke = value;
            }
        }

        public int Planet
        {
            get
            {
                return this._planet;
            }
            set
            {
                this._planet = value;
            }
        }

        public string PlanetName
        {
            get
            {
                return this._planetname;
            }
            set
            {
                this._planetname = value;
            }
        }

        public string PlanetNameEnglish
        {
            get
            {
                return this._planetnameenglish;
            }
            set
            {
                this._planetnameenglish = value;
            }
        }

        public string PlanetNameHindi
        {
            get
            {
                return this._planetnamehindi;
            }
            set
            {
                this._planetnamehindi = value;
            }
        }

        public int Rashi
        {
            get
            {
                return this._rashi;
            }
            set
            {
                this._rashi = value;
            }
        }

        public bool Shresht
        {
            get
            {
                return this._shresht;
            }
            set
            {
                this._shresht = value;
            }
        }

        public long Sno
        {
            get
            {
                return this._sno;
            }
            set
            {
                this._sno = value;
            }
        }

        public bool Soya
        {
            get
            {
                return this._soya;
            }
            set
            {
                this._soya = value;
            }
        }

        public bool Uch
        {
            get
            {
                return this._uch;
            }
            set
            {
                this._uch = value;
            }
        }

        public bool VIsBad
        {
            get
            {
                return this._visbad;
            }
            set
            {
                this._visbad = value;
            }
        }

        public KundliMappingVO()
        {
        }
    }
}