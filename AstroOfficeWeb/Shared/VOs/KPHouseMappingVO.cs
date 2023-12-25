using System;
using System.Collections.Generic;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KPHouseMappingVO
    {
        private short _house;

        private short _rashi;

        private short _laganrashi;

        private string _house_deg;

        private double _house_deg_decimal;

        private short _rashi_lord;

        private short _nak_lord;

        private short _sub_lord;

        private bool _is_manda;

        private List<KPSigniVO> _signi = new List<KPSigniVO>();

        private short _sub_sub_lord;

        public string DegreeHouse
        {
            get
            {
                return _house_deg;
            }
            set
            {
                _house_deg = value;
            }
        }

        public double DegreeHouse_Decimal
        {
            get
            {
                return _house_deg_decimal;
            }
            set
            {
                _house_deg_decimal = value;
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

        public bool Is_Manda
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

        public short LaganRashi
        {
            get
            {
                return _laganrashi;
            }
            set
            {
                _laganrashi = value;
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

        public KPHouseMappingVO()
        {
        }
    }
}