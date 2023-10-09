using System;

namespace ASDLL
{
    public class NepaliDate
    {
        private string _nepaliDate = string.Empty;

        private int _npDaysInMonth;

        private int _npYear;

        private int _npMonth;

        private int _npDay;

        public string npDate
        {
            get
            {
                return this._nepaliDate;
            }
            set
            {
                this._nepaliDate = value;
            }
        }

        public int npDay
        {
            get
            {
                return this._npDay;
            }
            set
            {
                this._npDay = value;
            }
        }

        public int npDaysInMonth
        {
            get
            {
                return this._npDaysInMonth;
            }
            set
            {
                this._npDaysInMonth = value;
            }
        }

        public int npMonth
        {
            get
            {
                return this._npMonth;
            }
            set
            {
                this._npMonth = value;
            }
        }

        public int npYear
        {
            get
            {
                return this._npYear;
            }
            set
            {
                this._npYear = value;
            }
        }

        public NepaliDate()
        {
        }
    }
}