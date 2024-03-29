using System;

namespace AstroShared.Models
{
    public class DrishtiVO
    {
        private int _sno;

        private int _planet1;

        private int _planet2;

        private int _house1;

        private int _house2;

        private int _percentage;

        public int House1
        {
            get
            {
                return _house1;
            }
            set
            {
                _house1 = value;
            }
        }

        public int House2
        {
            get
            {
                return _house2;
            }
            set
            {
                _house2 = value;
            }
        }

        public int Percentage
        {
            get
            {
                return _percentage;
            }
            set
            {
                _percentage = value;
            }
        }

        public int Planet1
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

        public int Planet2
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

        public DrishtiVO()
        {
        }
    }
}