using System;

namespace AstroShared.Models
{
    public class SoyeGrehUpayeVO
    {
        private int _sno;

        private int _planet;

        private string _details;

        private string _eng_details;

        private string _bangla_details;

        private string _tamil_details;

        private string _telugu_details;

        private string _kannada_details;

        private string _marathi_details;

        private string _punjabi_details;

        private string _gujarati_details;

        public string Bangla_Details
        {
            get
            {
                return _bangla_details;
            }
            set
            {
                _bangla_details = value;
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
            }
        }

        public string Eng_Details
        {
            get
            {
                return _eng_details;
            }
            set
            {
                _eng_details = value;
            }
        }

        public string Gujarati_Details
        {
            get
            {
                return _gujarati_details;
            }
            set
            {
                _gujarati_details = value;
            }
        }

        public string Kannada_Details
        {
            get
            {
                return _kannada_details;
            }
            set
            {
                _kannada_details = value;
            }
        }

        public string Marathi_Details
        {
            get
            {
                return _marathi_details;
            }
            set
            {
                _marathi_details = value;
            }
        }

        public int Planet
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

        public string Punjabi_Details
        {
            get
            {
                return _punjabi_details;
            }
            set
            {
                _punjabi_details = value;
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

        public string Tamil_Details
        {
            get
            {
                return _tamil_details;
            }
            set
            {
                _tamil_details = value;
            }
        }

        public string Telugu_Details
        {
            get
            {
                return _telugu_details;
            }
            set
            {
                _telugu_details = value;
            }
        }

        public SoyeGrehUpayeVO()
        {
        }
    }
}