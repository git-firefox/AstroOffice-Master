using System;

namespace AstroShared.Models
{
    public class LangVO
    {
        private int _ruleno;

        private string _common_pred;

        private string _male_pred;

        private string _female_pred;

        private string _child_pred;

        public string Child_Pred
        {
            get
            {
                return _child_pred;
            }
            set
            {
                _child_pred = value;
            }
        }

        public string Common_Pred
        {
            get
            {
                return _common_pred;
            }
            set
            {
                _common_pred = value;
            }
        }

        public string Female_Pred
        {
            get
            {
                return _female_pred;
            }
            set
            {
                _female_pred = value;
            }
        }

        public string Male_Pred
        {
            get
            {
                return _male_pred;
            }
            set
            {
                _male_pred = value;
            }
        }

        public int Rule_Number
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

        public LangVO()
        {
        }
    }
}