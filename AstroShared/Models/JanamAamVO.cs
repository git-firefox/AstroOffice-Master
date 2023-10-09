using System;

namespace AstroShared.Models
{
    public class JanamAamVO
    {
        private long _years;

        private string _planet;

        private string _antar;

        public string Antar
        {
            get
            {
                return _antar;
            }
            set
            {
                _antar = value;
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

        public JanamAamVO()
        {
        }
    }
}