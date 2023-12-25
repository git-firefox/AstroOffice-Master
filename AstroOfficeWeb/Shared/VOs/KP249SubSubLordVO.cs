using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KP249SubSubLordVO
    {
        private short _planet;

        private string _from_degree;

        private string _to_degree;

        private double _from_degree_decimal;

        private double _to_degree_decimal;

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

        public KP249SubSubLordVO()
        {
        }
    }
}