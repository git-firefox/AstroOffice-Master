using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AstroShared.Models
{
    public class KPNAKVO
    {
        private List<KPDashaRashiVO> _dasha_rashi = new List<KPDashaRashiVO>();

        public string Assamese
        {
            get;
            set;
        }

        public string Bangla
        {
            get;
            set;
        }

        public List<KPDashaRashiVO> DashaRashi
        {
            get
            {
                return this._dasha_rashi;
            }
            set
            {
                this._dasha_rashi = value;
            }
        }

        public string English
        {
            get;
            set;
        }

        public string Gujarati
        {
            get;
            set;
        }

        public string Hindi
        {
            get;
            set;
        }

        public string Kannada
        {
            get;
            set;
        }

        public string Malayalam
        {
            get;
            set;
        }

        public string Marathi
        {
            get;
            set;
        }

        public short NakNumber
        {
            get;
            set;
        }

        public string Oriya
        {
            get;
            set;
        }

        public string Punjabi
        {
            get;
            set;
        }

        public short Swami
        {
            get;
            set;
        }

        public string Tamil
        {
            get;
            set;
        }

        public string Telugu
        {
            get;
            set;
        }

        public KPNAKVO()
        {
        }
    }
}