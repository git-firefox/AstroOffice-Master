using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared
{
    public class SelectListItem
    {
        public bool Disabled { get; set; }
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public SelectListItem(string text, string value, bool disabled = false, bool selected = false)
        {
            Disabled = disabled;
            Selected = selected;
            Text = text;
            Value = value;
        }
    }
}
