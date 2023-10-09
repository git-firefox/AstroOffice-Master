using System;

namespace AstroShared.Models
{
    public class LagnaVO
    {
        private int _sno;

        private int _rashi;

        private int _planet1;

        private int _planet2;

        private int _house;

        private string _pred;

        public int house
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

        public string pred
        {
            get
            {
                return _pred;
            }
            set
            {
                _pred = value;
            }
        }

        public int rashi
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

        public LagnaVO()
        {
        }
    }
}