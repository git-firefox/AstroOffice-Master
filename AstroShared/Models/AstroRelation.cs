using System;

namespace AstroShared.Models
{
    public class AstroRelation
    {
        private int _sno;

        private int _planet1;

        private int _planet2;

        private int _relation;

        public int planet1
        {
            get
            {
                return _planet1;
            }
            set
            {
                _planet1 = value;
            }
        }

        public int planet2
        {
            get
            {
                return _planet2;
            }
            set
            {
                _planet2 = value;
            }
        }

        public int relation
        {
            get
            {
                return _relation;
            }
            set
            {
                _relation = value;
            }
        }

        public int sno
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

        public AstroRelation()
        {
        }
    }
}