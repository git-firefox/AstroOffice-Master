using System;

namespace AstroShared.Models
{
    public class UpayIndex
    {
        private int _sno;

        private string _hindi;

        private string _eng;

        private string _tamil;

        private string _telugu;

        private string _kannada;

        private string _bangla;

        private string _marathi;

        private string _punjabi;

        private string _gujarati;

        public string Bangla
        {
            get
            {
                return _bangla;
            }
            set
            {
                _bangla = value;
            }
        }

        public string Eng
        {
            get
            {
                return _eng;
            }
            set
            {
                _eng = value;
            }
        }

        public string Gujarati
        {
            get
            {
                return _gujarati;
            }
            set
            {
                _gujarati = value;
            }
        }

        public string Hindi
        {
            get
            {
                return _hindi;
            }
            set
            {
                _hindi = value;
            }
        }

        public string Kannada
        {
            get
            {
                return _kannada;
            }
            set
            {
                _kannada = value;
            }
        }

        public string Marathi
        {
            get
            {
                return _marathi;
            }
            set
            {
                _marathi = value;
            }
        }

        public string Punjabi
        {
            get
            {
                return _punjabi;
            }
            set
            {
                _punjabi = value;
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

        public string Tamil
        {
            get
            {
                return _tamil;
            }
            set
            {
                _tamil = value;
            }
        }

        public string Telugu
        {
            get
            {
                return _telugu;
            }
            set
            {
                _telugu = value;
            }
        }

        public UpayIndex()
        {
        }
    }
}