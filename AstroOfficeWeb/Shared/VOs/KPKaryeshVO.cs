using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KPKaryeshVO
    {
        private short _sno;

        private string _ktype;

        private short _main_house;

        private string _pos_houses;

        private string _neg_houses;

        public string KType
        {
            get
            {
                return _ktype;
            }
            set
            {
                _ktype = value;
            }
        }

        public short MainHose
        {
            get
            {
                return _main_house;
            }
            set
            {
                _main_house = value;
            }
        }

        public string Neg_House
        {
            get
            {
                return _neg_houses;
            }
            set
            {
                _neg_houses = value;
            }
        }

        public string Pos_Houses
        {
            get
            {
                return _pos_houses;
            }
            set
            {
                _pos_houses = value;
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

        public KPKaryeshVO()
        {
        }
    }
}