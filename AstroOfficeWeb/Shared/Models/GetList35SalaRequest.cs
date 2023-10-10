using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetList35SalaRequest
    {
        public string? Online_Result { get; set; }
        public KundliVO? PersKV { get; set; }
        public DateTime Dasha_Starts { get; set; }
        public DateTime Dasha_Ends { get; set; }
    }
}
