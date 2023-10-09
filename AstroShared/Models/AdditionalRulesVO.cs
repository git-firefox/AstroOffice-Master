using System;

namespace AstroShared.Models
{
    public class AdditionalRulesVO
    {
        private long _sno;

        private long _ruleno;

        private string _lagan;

        private string _rashi;

        public string Lagan
        {
            get
            {
                return _lagan;
            }
            set
            {
                _lagan = value;
            }
        }

        public string Rashi
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

        public long RuleNo
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

        public AdditionalRulesVO()
        {
        }
    }
}