using System;

namespace ASDLL
{
    public class AstroGlobal
    {
        public static long _activeid;

        public static bool _isserver;

        private static bool _online;

        private static string _astroConnectionString = string.Empty;
        private static string _astroEntities = string.Empty;

        private static string _username = string.Empty;

        private static long _eksno;

        private static long _abc_1;

        private static long _abc_2;

        private static int _house;

        private static short _mm_married;

        private static short _mm_profession;

        private static short _mm_wealth;

        private static short _mm_child;

        private static short _mm_health;

        private static short _mm_love;

        private static short _mf_married;

        private static short _mf_profession;

        private static short _mf_wealth;

        private static short _mf_child;

        private static short _mf_health;

        private static short _mf_love;

        private static short _mf_total;

        private static short _mm_total;

        private static string _concl = string.Empty;

        private static bool _validkey;

        public static long ABC_1
        {
            get
            {
                return AstroGlobal._abc_1;
            }
            set
            {
                AstroGlobal._abc_1 = value;
            }
        }

        public static long ABC_2
        {
            get
            {
                return AstroGlobal._abc_2;
            }
            set
            {
                AstroGlobal._abc_2 = value;
            }
        }

        public static long ActiveID
        {
            get
            {
                return AstroGlobal._activeid;
            }
            set
            {
                AstroGlobal._activeid = value;
            }
        }

        public static string Concl
        {
            get
            {
                return AstroGlobal._concl;
            }
            set
            {
                AstroGlobal._concl = value;
            }
        }

        public static string AstroConnectionString
        {
            get
            {
                return AstroGlobal._astroConnectionString;
            }
            set
            {
                AstroGlobal._astroConnectionString = value;
            }
        }
        public static string AstroEntities
        {
            get
            {
                return AstroGlobal._astroEntities;
            }
            set
            {
                AstroGlobal._astroEntities = value;
            }
        }

        public static long EKSNO
        {
            get
            {
                return AstroGlobal._eksno;
            }
            set
            {
                AstroGlobal._eksno = value;
            }
        }

        public static int House
        {
            get
            {
                return AstroGlobal._house;
            }
            set
            {
                AstroGlobal._house = value;
            }
        }

        public static bool IsServer
        {
            get
            {
                return AstroGlobal._isserver;
            }
            set
            {
                AstroGlobal._isserver = value;
            }
        }

        public static short MF_child
        {
            get
            {
                return AstroGlobal._mf_child;
            }
            set
            {
                AstroGlobal._mf_child = value;
            }
        }

        public static short MF_health
        {
            get
            {
                return AstroGlobal._mf_health;
            }
            set
            {
                AstroGlobal._mf_health = value;
            }
        }

        public static short MF_love
        {
            get
            {
                return AstroGlobal._mf_love;
            }
            set
            {
                AstroGlobal._mf_love = value;
            }
        }

        public static short MF_married
        {
            get
            {
                return AstroGlobal._mf_married;
            }
            set
            {
                AstroGlobal._mf_married = value;
            }
        }

        public static short MF_profession
        {
            get
            {
                return AstroGlobal._mf_profession;
            }
            set
            {
                AstroGlobal._mf_profession = value;
            }
        }

        public static short MF_total
        {
            get
            {
                return AstroGlobal._mf_total;
            }
            set
            {
                AstroGlobal._mf_total = value;
            }
        }

        public static short MF_wealth
        {
            get
            {
                return AstroGlobal._mf_wealth;
            }
            set
            {
                AstroGlobal._mf_wealth = value;
            }
        }

        public static short MM_child
        {
            get
            {
                return AstroGlobal._mm_child;
            }
            set
            {
                AstroGlobal._mm_child = value;
            }
        }

        public static short MM_health
        {
            get
            {
                return AstroGlobal._mm_health;
            }
            set
            {
                AstroGlobal._mm_health = value;
            }
        }

        public static short MM_love
        {
            get
            {
                return AstroGlobal._mm_love;
            }
            set
            {
                AstroGlobal._mm_love = value;
            }
        }

        public static short MM_married
        {
            get
            {
                return AstroGlobal._mm_married;
            }
            set
            {
                AstroGlobal._mm_married = value;
            }
        }

        public static short MM_profession
        {
            get
            {
                return AstroGlobal._mm_profession;
            }
            set
            {
                AstroGlobal._mm_profession = value;
            }
        }

        public static short MM_total
        {
            get
            {
                return AstroGlobal._mm_total;
            }
            set
            {
                AstroGlobal._mm_total = value;
            }
        }

        public static short MM_wealth
        {
            get
            {
                return AstroGlobal._mm_wealth;
            }
            set
            {
                AstroGlobal._mm_wealth = value;
            }
        }

        public static bool Online
        {
            get
            {
                return AstroGlobal._online;
            }
            set
            {
                AstroGlobal._online = value;
            }
        }

        public static string Username
        {
            get
            {
                return AstroGlobal._username;
            }
            set
            {
                AstroGlobal._username = value;
            }
        }

        public static bool ValidKey
        {
            get
            {
                return AstroGlobal._validkey;
            }
            set
            {
                AstroGlobal._validkey = value;
            }
        }

        static AstroGlobal()
        {
            AstroGlobal._validkey = false;
        }

        public AstroGlobal()
        {
        }
    }
}