using System;

namespace AstroOfficeWeb.Shared.VOs
{
    public class UsersVO
    {
        private long _sno;

        private string _username;

        private string _password;

        private bool _active;

        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
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

        public UsersVO()
        {
        }
    }
}