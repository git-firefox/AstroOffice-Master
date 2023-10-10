using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetKpLangRequest
    {
        public short MixSno { get; set; }
        public string Language { get; set; }
        public bool Dashafal { get; set; }
        public bool Upay { get; set; }
        public bool Mini { get; set; }
    }
}
