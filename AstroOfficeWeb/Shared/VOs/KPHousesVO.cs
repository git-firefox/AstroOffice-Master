using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KPHousesVO
    {
        private short _house;

        private short _swami;

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

        public short Swami
        {
            get
            {
                return _swami;
            }
            set
            {
                _swami = value;
            }
        }

        public KPHousesVO()
        {
        }
    }
}