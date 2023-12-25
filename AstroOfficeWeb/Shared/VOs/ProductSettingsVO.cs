using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AstroOfficeWeb.Shared.VOs
{
    public class ProductSettingsVO
    {
        private bool _link = false;

        private bool _mobile = false;

        private bool _showmanyavar = true;

        private bool _onlymahadasha = false;

        private bool _nocategory = false;

        private bool _current_mahadasha = false;

        private bool _free_upay = false;

        private bool _only_upay = false;

        private bool _tool = false;

        private bool _karyesh = false;

        private short _fulltype = 0;

        private short _fulltype_planet = 0;

        private bool _mini = false;

        private bool _matchmaking = false;

        private bool _tool507 = false;

        private bool _json = false;

        private bool _belowupay = false;

        private bool _astroarmy = false;

        private bool _paid = true;

        private bool _vfal = false;

        private bool _inc_category = true;

        [DefaultValue(false)]
        public bool AstroArmy
        {
            get
            {
                return _astroarmy;
            }
            set
            {
                _astroarmy = value;
            }
        }

        public string Category
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool CurrentMahadasha
        {
            get
            {
                return _current_mahadasha;
            }
            set
            {
                _current_mahadasha = value;
            }
        }

        public short Dasha_Years
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool FreeUpay
        {
            get
            {
                return _free_upay;
            }
            set
            {
                _free_upay = value;
            }
        }

        [DefaultValue(0)]
        public short fulltype
        {
            get
            {
                return _fulltype;
            }
            set
            {
                _fulltype = value;
            }
        }

        [DefaultValue(0)]
        public short fulltype_planet
        {
            get
            {
                return _fulltype_planet;
            }
            set
            {
                _fulltype_planet = value;
            }
        }

        [DefaultValue(false)]
        public bool Gen_Link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
            }
        }

        public bool Include
        {
            get;
            set;
        }

        [DefaultValue(true)]
        public bool Include_Category
        {
            get
            {
                return _inc_category;
            }
            set
            {
                _inc_category = value;
            }
        }

        [DefaultValue(false)]
        public bool Json
        {
            get
            {
                return _json;
            }
            set
            {
                _json = value;
            }
        }

        [DefaultValue(false)]
        public bool Karyesh
        {
            get
            {
                return _karyesh;
            }
            set
            {
                _karyesh = value;
            }
        }

        public string Lang
        {
            get;
            set;
        }

        public bool Male
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool Matchmaking
        {
            get
            {
                return _matchmaking;
            }
            set
            {
                _matchmaking = value;
            }
        }

        [DefaultValue(false)]
        public bool Mini
        {
            get
            {
                return _mini;
            }
            set
            {
                _mini = value;
            }
        }

        [DefaultValue(false)]
        public bool Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
            }
        }

        [DefaultValue(false)]
        public bool NoCategory
        {
            get
            {
                return _nocategory;
            }
            set
            {
                _nocategory = value;
            }
        }

        public string Online_Result
        {
            get;
            set;
        }

        public bool Only_Chain
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool OnlyMahadasha
        {
            get
            {
                return _onlymahadasha;
            }
            set
            {
                _onlymahadasha = value;
            }
        }

        [DefaultValue(false)]
        public bool OnlyUpay
        {
            get
            {
                return _only_upay;
            }
            set
            {
                _only_upay = value;
            }
        }

        [DefaultValue(true)]
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

        public short PredFor
        {
            get;
            set;
        }

        public string Product
        {
            get;
            set;
        }

        public string Product_Name
        {
            get;
            set;
        }

        public short Rotate
        {
            get;
            set;
        }

        [DefaultValue(true)]
        public bool ShowManyavar
        {
            get
            {
                return _showmanyavar;
            }
            set
            {
                _showmanyavar = value;
            }
        }

        public bool ShowRef
        {
            get;
            set;
        }

        public bool ShowUpay
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool ShowUpayBelow
        {
            get
            {
                return _belowupay;
            }
            set
            {
                _belowupay = value;
            }
        }

        public bool ShowUpayCode
        {
            get;
            set;
        }

        public long Sno
        {
            get;
            set;
        }

        public short Start_Year
        {
            get;
            set;
        }

        public string subproduct
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool Tool
        {
            get
            {
                return _tool;
            }
            set
            {
                _tool = value;
            }
        }

        [DefaultValue(false)]
        public bool Tool507
        {
            get
            {
                return _tool507;
            }
            set
            {
                _tool507 = value;
            }
        }

        [DefaultValue(false)]
        public bool Vfal
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

        public ProductSettingsVO()
        {
            Category = string.Empty;
            Lang = string.Empty;
            Online_Result = string.Empty;
            subproduct = string.Empty;
            Product = string.Empty;
            Product_Name = string.Empty;
        }
    }
}