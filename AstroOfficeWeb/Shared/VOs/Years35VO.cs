using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class Years35VO
    {
        private long _sno;

        private long _years;

        private string _planet;

        private string _mid1;

        private string _mid2;

        private string _mid3;

        private string _period;

        public string Mid1
        {
            get
            {
                return _mid1;
            }
            set
            {
                _mid1 = value;
            }
        }

        public string Mid2
        {
            get
            {
                return _mid2;
            }
            set
            {
                _mid2 = value;
            }
        }

        public string Mid3
        {
            get
            {
                return _mid3;
            }
            set
            {
                _mid3 = value;
            }
        }

        public string Period
        {
            get
            {
                return _period;
            }
            set
            {
                _period = value;
            }
        }

        public string Planet
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

        public long Years
        {
            get
            {
                return _years;
            }
            set
            {
                _years = value;
            }
        }

        public Years35VO()
        {
        }
    }
}