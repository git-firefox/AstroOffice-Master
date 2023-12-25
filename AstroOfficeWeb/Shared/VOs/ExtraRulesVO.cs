using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class ExtraRulesVO
    {
        private long _sno;

        private long _ruleno;

        private bool _good;

        private string _planet;

        private bool _isplanet;

        public bool Good
        {
            get
            {
                return _good;
            }
            set
            {
                _good = value;
            }
        }

        public bool IsPlanet
        {
            get
            {
                return _isplanet;
            }
            set
            {
                _isplanet = value;
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

        public long RuleNo
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

        public ExtraRulesVO()
        {
        }
    }
}