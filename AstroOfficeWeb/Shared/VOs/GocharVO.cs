using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class GocharVO
    {
        private short _sno;

        private short _planet;

        private short _rashi;

        private short _house;

        private DateTime _entrydate;

        private DateTime _exitdate;

        public DateTime Entrydate
        {
            get
            {
                return _entrydate;
            }
            set
            {
                _entrydate = value;
            }
        }

        public DateTime Exitdate
        {
            get
            {
                return _exitdate;
            }
            set
            {
                _exitdate = value;
            }
        }

        public short House
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

        public short Planet
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

        public short Rashi
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

        public GocharVO()
        {
        }
    }
}