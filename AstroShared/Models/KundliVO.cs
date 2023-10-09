using System;

namespace AstroShared.Models
{
    public class KundliVO
    {
        private long _sno;

        private string _name = string.Empty;

        private DateTime _dob;

        private DateTime _tob;

        private DateTime _gochar_date_1;

        private DateTime _gochar_date_2;

        private string _placeofbirth = string.Empty;

        private long _lagna;

        private long _base_lagna;

        private long _nak;

        private short _current_age;

        private long _charan;

        private string _online_result = string.Empty;

        private string _online_result_gochar = string.Empty;

        private double _lon;

        private double _lat;

        private double _timezone;

        private string _janamsamay = string.Empty;

        private string _janamdin = string.Empty;

        private string _remarks = string.Empty;

        private string _username = string.Empty;

        private DateTime _entrytime;

        private bool _paid;

        private bool _showref;

        private string _sub_prodtype = string.Empty;

        private bool _mfal;

        private short _rotate;

        private string _dasha35 = string.Empty;

        private string _antar35 = string.Empty;

        private string _dasha_visho = string.Empty;

        private string _antar_visho = string.Empty;

        private string _pryantar_visho = string.Empty;

        private string _ratna = string.Empty;

        private string _upratna = string.Empty;

        private string _ratnacode = string.Empty;

        private string _dd = string.Empty;

        private string _mm = string.Empty;

        private string _yy = string.Empty;

        private string _Wdd = string.Empty;

        private string _Wmm = string.Empty;

        private string _Wyy = string.Empty;

        private string _hh = string.Empty;

        private string _min = string.Empty;

        private string _ss = string.Empty;

        private bool _male;

        private string _language = string.Empty;

        private string _lucky_day1 = string.Empty;

        private string _lucky_day2 = string.Empty;

        private string _lucky_number = string.Empty;

        private string _janam_lagna = string.Empty;

        private string _janam_rashi = string.Empty;

        private string _domain = string.Empty;

        private string _vcn_prefix = string.Empty;

        private string _file_prefix = string.Empty;

        private string _source = string.Empty;

        private string _headertitle = string.Empty;

        private string _product = string.Empty;

        private long _orderno;

        private string _lonstr = string.Empty;

        private string _latstr = string.Empty;

        private string _timezonestr = string.Empty;

        private bool _manual;

        private string _machine = string.Empty;

        private string _filecode = string.Empty;

        private string _upaycode = string.Empty;

        public string Antar_Visho
        {
            get
            {
                return _antar_visho;
            }
            set
            {
                _antar_visho = value;
            }
        }

        public string Antar35
        {
            get
            {
                return _antar35;
            }
            set
            {
                _antar35 = value;
            }
        }

        public long Base_Lagna
        {
            get
            {
                return _base_lagna;
            }
            set
            {
                _base_lagna = value;
            }
        }

        public long Charan
        {
            get
            {
                return _charan;
            }
            set
            {
                _charan = value;
            }
        }

        public short Current_Age
        {
            get
            {
                return _current_age;
            }
            set
            {
                _current_age = value;
            }
        }

        public string Dasha_Visho
        {
            get
            {
                return _dasha_visho;
            }
            set
            {
                _dasha_visho = value;
            }
        }

        public string Dasha35
        {
            get
            {
                return _dasha35;
            }
            set
            {
                _dasha35 = value;
            }
        }

        public string DD
        {
            get
            {
                return _dd;
            }
            set
            {
                _dd = value;
            }
        }

        public DateTime Dob
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
            }
        }

        public string Domain
        {
            get
            {
                return _domain;
            }
            set
            {
                _domain = value;
            }
        }

        public DateTime EntryTime
        {
            get
            {
                return _entrytime;
            }
            set
            {
                _entrytime = value;
            }
        }

        public string File_Prefix
        {
            get
            {
                return _file_prefix;
            }
            set
            {
                _file_prefix = value;
            }
        }

        public string FileCode
        {
            get
            {
                return _filecode;
            }
            set
            {
                _filecode = value;
            }
        }

        public DateTime Gochar_Date_1
        {
            get
            {
                return _gochar_date_1;
            }
            set
            {
                _gochar_date_1 = value;
            }
        }

        public DateTime Gochar_Date_2
        {
            get
            {
                return _gochar_date_2;
            }
            set
            {
                _gochar_date_2 = value;
            }
        }

        public string HeaderTitle
        {
            get
            {
                return _headertitle;
            }
            set
            {
                _headertitle = value;
            }
        }

        public string HH
        {
            get
            {
                return _hh;
            }
            set
            {
                _hh = value;
            }
        }

        public string Janam_Lagna
        {
            get
            {
                return _janam_lagna;
            }
            set
            {
                _janam_lagna = value;
            }
        }

        public string Janam_rashi
        {
            get
            {
                return _janam_rashi;
            }
            set
            {
                _janam_rashi = value;
            }
        }

        public string JanamDin
        {
            get
            {
                return _janamdin;
            }
            set
            {
                _janamdin = value;
            }
        }

        public string JanamSamay
        {
            get
            {
                return _janamsamay;
            }
            set
            {
                _janamsamay = value;
            }
        }

        public long Lagna
        {
            get
            {
                return _lagna;
            }
            set
            {
                _lagna = value;
            }
        }

        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        public double Lat
        {
            get
            {
                return _lat;
            }
            set
            {
                _lat = value;
            }
        }

        public string Latstr
        {
            get
            {
                return _latstr;
            }
            set
            {
                _latstr = value;
            }
        }

        public double Lon
        {
            get
            {
                return _lon;
            }
            set
            {
                _lon = value;
            }
        }

        public string Lonstr
        {
            get
            {
                return _lonstr;
            }
            set
            {
                _lonstr = value;
            }
        }

        public string Lucky_day1
        {
            get
            {
                return _lucky_day1;
            }
            set
            {
                _lucky_day1 = value;
            }
        }

        public string Lucky_day2
        {
            get
            {
                return _lucky_day2;
            }
            set
            {
                _lucky_day2 = value;
            }
        }

        public string Lucky_number
        {
            get
            {
                return _lucky_number;
            }
            set
            {
                _lucky_number = value;
            }
        }

        public string Machine
        {
            get
            {
                return _machine;
            }
            set
            {
                _machine = value;
            }
        }

        public bool Male
        {
            get
            {
                return _male;
            }
            set
            {
                _male = value;
            }
        }

        public bool Manual
        {
            get
            {
                return _manual;
            }
            set
            {
                _manual = value;
            }
        }

        public bool Mfal
        {
            get
            {
                return _mfal;
            }
            set
            {
                _mfal = value;
            }
        }

        public string MIN
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }

        public string MM
        {
            get
            {
                return _mm;
            }
            set
            {
                _mm = value;
            }
        }

        public long Nak
        {
            get
            {
                return _nak;
            }
            set
            {
                _nak = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Online_Result
        {
            get
            {
                return _online_result;
            }
            set
            {
                _online_result = value;
            }
        }

        public string Online_Result_Gochar
        {
            get
            {
                return _online_result_gochar;
            }
            set
            {
                _online_result_gochar = value;
            }
        }

        public long Orderno
        {
            get
            {
                return _orderno;
            }
            set
            {
                _orderno = value;
            }
        }

        public bool Paid
        {
            get
            {
                return _paid;
            }
            set
            {
                _paid = value;
            }
        }

        public string Placeofbirth
        {
            get
            {
                return _placeofbirth;
            }
            set
            {
                _placeofbirth = value;
            }
        }

        public string Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public string Pryantar_Visho
        {
            get
            {
                return _pryantar_visho;
            }
            set
            {
                _pryantar_visho = value;
            }
        }

        public string Ratna
        {
            get
            {
                return _ratna;
            }
            set
            {
                _ratna = value;
            }
        }

        public string RatnaCode
        {
            get
            {
                return _ratnacode;
            }
            set
            {
                _ratnacode = value;
            }
        }

        public string Remarks
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }

        public short Rotate
        {
            get
            {
                return _rotate;
            }
            set
            {
                _rotate = value;
            }
        }

        public bool ShowRef
        {
            get
            {
                return _showref;
            }
            set
            {
                _showref = value;
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

        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        public string SS
        {
            get
            {
                return _ss;
            }
            set
            {
                _ss = value;
            }
        }

        public string Sub_prodtype
        {
            get
            {
                return _sub_prodtype;
            }
            set
            {
                _sub_prodtype = value;
            }
        }

        public double TimeZone
        {
            get
            {
                return _timezone;
            }
            set
            {
                _timezone = value;
            }
        }

        public string Timezonestr
        {
            get
            {
                return _timezonestr;
            }
            set
            {
                _timezonestr = value;
            }
        }

        public DateTime Tob
        {
            get
            {
                return _tob;
            }
            set
            {
                _tob = value;
            }
        }

        public string UpayCode
        {
            get
            {
                return _upaycode;
            }
            set
            {
                _upaycode = value;
            }
        }

        public string Upratna
        {
            get
            {
                return _upratna;
            }
            set
            {
                _upratna = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string VCN_Prefix
        {
            get
            {
                return _vcn_prefix;
            }
            set
            {
                _vcn_prefix = value;
            }
        }

        public string WDD
        {
            get
            {
                return _Wdd;
            }
            set
            {
                _Wdd = value;
            }
        }

        public string WMM
        {
            get
            {
                return _Wmm;
            }
            set
            {
                _Wmm = value;
            }
        }

        public string WYY
        {
            get
            {
                return _Wyy;
            }
            set
            {
                _Wyy = value;
            }
        }

        public string YY
        {
            get
            {
                return _yy;
            }
            set
            {
                _yy = value;
            }
        }

        public KundliVO()
        {
        }
    }
}