using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Utilities
{
    public class Option
    {
        public string Text { get; set; } = null!;
        public object Value { get; set; } = default!;

        public Option() { }
        public Option(string? text, object value)
        {
            Text = text ?? string.Empty;
            Value = value;
        }
    }
}
