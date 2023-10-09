using System;

namespace AstroOffice.Helper
{
    internal class AstroGlobal
    {
        private static string _activeusername;

        private static DateTime _lastlogin;

        private static long _sno;

        private static bool _isadmin;

        private static bool _canaddnew;

        private static bool _canmodify;

        private static bool _canreport;

        private static bool _upayb_mangal;

        public static long ActiveUserId
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

        public static bool CanAddNew
        {
            get
            {
                return _canaddnew;
            }
            set
            {
                _canaddnew = value;
            }
        }

        public static bool CanModify
        {
            get
            {
                return _canmodify;
            }
            set
            {
                _canmodify = value;
            }
        }

        public static bool CanReport
        {
            get
            {
                return _canreport;
            }
            set
            {
                _canreport = value;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                return _isadmin;
            }
            set
            {
                _isadmin = value;
            }
        }

        public static DateTime lastlogin
        {
            get
            {
                return _lastlogin;
            }
            set
            {
                _lastlogin = value;
            }
        }

        public static bool Upayb_Mangal
        {
            get
            {
                return _upayb_mangal;
            }
            set
            {
                _upayb_mangal = value;
            }
        }

        public static string Username
        {
            get
            {
                return _activeusername;
            }
            set
            {
                _activeusername = value;
            }
        }

        public AstroGlobal()
        {
        }
    }
}