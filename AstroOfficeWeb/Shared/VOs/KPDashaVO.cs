using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AstroOfficeWeb.Shared.VOs
{
    public class KPDashaVO
    {
        private List<KPSigniVO> _signi = new List<KPSigniVO>();

        private List<KPSigniVO> _naksigni = new List<KPSigniVO>();

        public long Days
        {
            get;
            set;
        }

        public string Duration
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public string Nak_Signi_String
        {
            get;
            set;
        }

        public List<KPSigniVO> NakSigni
        {
            get
            {
                return _naksigni;
            }
            set
            {
                _naksigni = value;
            }
        }

        public short Planet
        {
            get;
            set;
        }

        public List<KPSigniVO> Signi
        {
            get
            {
                return _signi;
            }
            set
            {
                _signi = value;
            }
        }

        public string Signi_String
        {
            get;
            set;
        }

        public short SNo
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public KPDashaVO()
        {
        }
    }
}