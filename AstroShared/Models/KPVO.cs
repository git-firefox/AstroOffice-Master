using System;

namespace AstroShared.Models
{
    public class KPVO
    {
        private long _sno;

        private long _kpno;

        private string _planet1;

        private string _planet2;

        private string _planet3;

        private string _kp_work;

        public string KP_Work
        {
            get
            {
                return _kp_work;
            }
            set
            {
                _kp_work = value;
            }
        }

        public long KPNo
        {
            get
            {
                return _kpno;
            }
            set
            {
                _kpno = value;
            }
        }

        public string Planet1
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

        public string Planet2
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

        public string Planet3
        {
            get
            {
                return _planet3;
            }
            set
            {
                _planet3 = value;
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

        public KPVO()
        {
        }
    }
}