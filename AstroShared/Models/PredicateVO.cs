using System;

namespace AstroShared.Models
{
    public class PredicateVO
    {
        private long _sno;

        private long _ruleno;

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

        public PredicateVO()
        {
        }
    }
}