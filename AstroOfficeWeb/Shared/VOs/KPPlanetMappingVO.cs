using System;
using System.Collections.Generic;

namespace AstroOfficeWeb.Shared.VOs
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
                return _bhav_chalit_house;
            }
            set
            {
                _bhav_chalit_house = value;
            }
        }

        public short Bhav_Chalit_House_New
        {
            get
            {
                return _bhav_chalit_house_new;
            }
            set
            {
                _bhav_chalit_house_new = value;
            }
        }

        public short Bhav_Chalit_Rashi
        {
            get
            {
                return _bhav_chalit_rashi;
            }
            set
            {
                _bhav_chalit_rashi = value;
            }
        }

        public string DegreePlanet
        {
            get
            {
                return _planet_deg;
            }
            set
            {
                _planet_deg = value;
            }
        }

        public double DegreePlanet_Decimal
        {
            get
            {
                return _planet_deg_decimal;
            }
            set
            {
                _planet_deg_decimal = value;
            }
        }

        public short House
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

        public bool isbad
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

        public bool isJadKharab
        {
            get
            {
                return _isjadkharab;
            }
            set
            {
                _isjadkharab = value;
            }
        }

        public bool isManda
        {
            get
            {
                return _is_manda;
            }
            set
            {
                _is_manda = value;
            }
        }

        public bool IsPakka
        {
            get
            {
                return _ispakka;
            }
            set
            {
                _ispakka = value;
            }
        }

        public bool IsVeryBad
        {
            get
            {
                return _isverybad;
            }
            set
            {
                _isverybad = value;
            }
        }

        public short Nak_Lord
        {
            get
            {
                return _nak_lord;
            }
            set
            {
                _nak_lord = value;
            }
        }

        public short Planet
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

        public short Rashi
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

        public short Rashi_Lord
        {
            get
            {
                return _rashi_lord;
            }
            set
            {
                _rashi_lord = value;
            }
        }

        public List<KPSigniVO> Signi
        {
            get
            {
                return _signi;
            }
            set
            {
                _signi = value;
            }
        }

        public short Sub_Lord
        {
            get
            {
                return _sub_lord;
            }
            set
            {
                _sub_lord = value;
            }
        }

        public short Sub_Sub_Lord
        {
            get
            {
                return _sub_sub_lord;
            }
            set
            {
                _sub_sub_lord = value;
            }
        }

        public KPPlanetMappingVO()
        {
            _planet_deg = string.Empty;
        }
    }
}