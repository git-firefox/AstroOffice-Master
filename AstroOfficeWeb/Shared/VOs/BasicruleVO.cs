using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class BasicruleVO
    {
        private int _sno;

        private int _house;

        private int _planet;

        private string _basicrule;

        public string Basicrule
        {
            get
            {
                return _basicrule;
            }
            set
            {
                _basicrule = value;
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

        public BasicruleVO()
        {
        }
    }
}