using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class iAstroUpayVO
    {
        private int _sno;

        private int _ruleno;

        private string _skip;

        private string _vfal;

        private string _pred;

        private string _pred_english;

        private string _pred_marathi;

        private string _pred_punjabi;

        private string _pred_gujarati;

        private string _pred_tamil;

        private string _pred_telugu;

        private string _pred_bangla;

        private string _pred_kannada;

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

        public string pred_bangla
        {
            get
            {
                return _pred_bangla;
            }
            set
            {
                _pred_bangla = value;
            }
        }

        public string pred_english
        {
            get
            {
                return _pred_english;
            }
            set
            {
                _pred_english = value;
            }
        }

        public string pred_gujarati
        {
            get
            {
                return _pred_gujarati;
            }
            set
            {
                _pred_gujarati = value;
            }
        }

        public string pred_kannada
        {
            get
            {
                return _pred_kannada;
            }
            set
            {
                _pred_kannada = value;
            }
        }

        public string pred_marathi
        {
            get
            {
                return _pred_marathi;
            }
            set
            {
                _pred_marathi = value;
            }
        }

        public string pred_punjabi
        {
            get
            {
                return _pred_punjabi;
            }
            set
            {
                _pred_punjabi = value;
            }
        }

        public string pred_tamil
        {
            get
            {
                return _pred_tamil;
            }
            set
            {
                _pred_tamil = value;
            }
        }

        public string pred_telugu
        {
            get
            {
                return _pred_telugu;
            }
            set
            {
                _pred_telugu = value;
            }
        }

        public int ruleno
        {
            get
            {
                return _ruleno;
            }
            set
            {
                _ruleno = value;
            }
        }

        public string skip
        {
            get
            {
                return _skip;
            }
            set
            {
                _skip = value;
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

        public string vfal
        {
            get
            {
                return _vfal;
            }
            set
            {
                _vfal = value;
            }
        }

        public iAstroUpayVO()
        {
        }
    }
}