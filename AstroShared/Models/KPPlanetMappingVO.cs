using System;
using System.Collections.Generic;

namespace AstroShared.Models
{
    public class KPPlanetMappingVO
    {
        private short _planet;

        private short _house;

        private short _rashi;

        private bool _isbad;

        private bool _isverybad;

        private short _bhav_chalit_house;

        private short _bhav_chalit_house_new;

        private short _bhav_chalit_rashi;

        private string _planet_deg;

        private double _planet_deg_decimal;

        private short _rashi_lord;

        private short _nak_lord;

        private short _sub_lord;

        private List<KPSigniVO> _signi = new List<KPSigniVO>();

        private short _sub_sub_lord;

        private bool _is_manda;

        private bool _isjadkharab;

        private bool _ispakka;

        public short Bhav_Chalit_House
        {
            get
            {
                return this._bhav_chalit_house;
            }
            set
            {
                this._bhav_chalit_house = value;
            }
        }

        public short Bhav_Chalit_House_New
        {
            get
            {
                return this._bhav_chalit_house_new;
            }
            set
            {
                this._bhav_chalit_house_new = value;
            }
        }

        public short Bhav_Chalit_Rashi
        {
            get
            {
                return this._bhav_chalit_rashi;
            }
            set
            {
                this._bhav_chalit_rashi = value;
            }
        }

        public string DegreePlanet
        {
            get
            {
                return this._planet_deg;
            }
            set
            {
                this._planet_deg = value;
            }
        }

        public double DegreePlanet_Decimal
        {
            get
            {
                return this._planet_deg_decimal;
            }
            set
            {
                this._planet_deg_decimal = value;
            }
        }

        public short House
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

        public bool isbad
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

        public bool isJadKharab
        {
            get
            {
                return this._isjadkharab;
            }
            set
            {
                this._isjadkharab = value;
            }
        }

        public bool isManda
        {
            get
            {
                return this._is_manda;
            }
            set
            {
                this._is_manda = value;
            }
        }

        public bool IsPakka
        {
            get
            {
                return this._ispakka;
            }
            set
            {
                this._ispakka = value;
            }
        }

        public bool IsVeryBad
        {
            get
            {
                return this._isverybad;
            }
            set
            {
                this._isverybad = value;
            }
        }

        public short Nak_Lord
        {
            get
            {
                return this._nak_lord;
            }
            set
            {
                this._nak_lord = value;
            }
        }

        public short Planet
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

        public short Rashi
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

        public short Rashi_Lord
        {
            get
            {
                return this._rashi_lord;
            }
            set
            {
                this._rashi_lord = value;
            }
        }

        public List<KPSigniVO> Signi
        {
            get
            {
                return this._signi;
            }
            set
            {
                this._signi = value;
            }
        }

        public short Sub_Lord
        {
            get
            {
                return this._sub_lord;
            }
            set
            {
                this._sub_lord = value;
            }
        }

        public short Sub_Sub_Lord
        {
            get
            {
                return this._sub_sub_lord;
            }
            set
            {
                this._sub_sub_lord = value;
            }
        }

        public KPPlanetMappingVO()
        {
        }
    }
}