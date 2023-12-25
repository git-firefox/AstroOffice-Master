using System;
using System.Collections.Generic;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KP249VO
    {
        private short _sno;

        private short _rashi;

        private string _from_degree;

        private string _to_degree;

        private double _from_degree_decimal;

        private double _to_degree_decimal;

        private short _rashi_lord;

        private short _nak_lord;

        private short _sub_lord;

        private List<KP249SubSubLordVO> _sub_sub_lord = new List<KP249SubSubLordVO>();

        public string From_Degree
        {
            get
            {
                return _from_degree;
            }
            set
            {
                _from_degree = value;
            }
        }

        public double From_Degree_Decimal
        {
            get
            {
                return _from_degree_decimal;
            }
            set
            {
                _from_degree_decimal = value;
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

        public short Sno
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

        public List<KP249SubSubLordVO> Sub_Sub_Lord
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

        public string To_Degree
        {
            get
            {
                return _to_degree;
            }
            set
            {
                _to_degree = value;
            }
        }

        public double To_Degree_Decimal
        {
            get
            {
                return _to_degree_decimal;
            }
            set
            {
                _to_degree_decimal = value;
            }
        }

        public KP249VO()
        {
        }
    }
}