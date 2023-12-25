using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class AntarVO
    {
        private string _planet;

        private string _mid1;

        private string _mid2;

        private string _mid3;

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

        public AntarVO()
        {
        }
    }
}