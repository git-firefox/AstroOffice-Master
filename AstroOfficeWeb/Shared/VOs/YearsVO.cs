using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class YearsVO
    {
        private short _sno;

        private short _ruleno;

        private short _year1_from;

        private short _year2_from;

        private short _year3_from;

        private short _year1_to;

        private short _year2_to;

        private short _year3_to;

        private string _age;

        private string _vfalyears;

        private bool _shishu;

        private bool _bachpan;

        private bool _kishor;

        private bool _yuva;

        private bool _madhya;

        private bool _budhapa;

        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public bool Bachpan
        {
            get
            {
                return _bachpan;
            }
            set
            {
                _bachpan = value;
            }
        }

        public bool Budhapa
        {
            get
            {
                return _budhapa;
            }
            set
            {
                _budhapa = value;
            }
        }

        public bool Kishor
        {
            get
            {
                return _kishor;
            }
            set
            {
                _kishor = value;
            }
        }

        public bool Madhya
        {
            get
            {
                return _madhya;
            }
            set
            {
                _madhya = value;
            }
        }

        public short RuleNo
        {
            get
            {
                return _ruleno;
            }
            set
            {
                _ruleno = value;
            }
        }

        public bool Shishu
        {
            get
            {
                return _shishu;
            }
            set
            {
                _shishu = value;
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

        public string VFalYears
        {
            get
            {
                return _vfalyears;
            }
            set
            {
                _vfalyears = value;
            }
        }

        public short Year1_From
        {
            get
            {
                return _year1_from;
            }
            set
            {
                _year1_from = value;
            }
        }

        public short Year1_To
        {
            get
            {
                return _year1_to;
            }
            set
            {
                _year1_to = value;
            }
        }

        public short Year2_From
        {
            get
            {
                return _year2_from;
            }
            set
            {
                _year2_from = value;
            }
        }

        public short Year2_To
        {
            get
            {
                return _year2_to;
            }
            set
            {
                _year2_to = value;
            }
        }

        public short Year3_From
        {
            get
            {
                return _year3_from;
            }
            set
            {
                _year3_from = value;
            }
        }

        public short Year3_To
        {
            get
            {
                return _year3_to;
            }
            set
            {
                _year3_to = value;
            }
        }

        public bool Yuva
        {
            get
            {
                return _yuva;
            }
            set
            {
                _yuva = value;
            }
        }

        public YearsVO()
        {
        }
    }
}