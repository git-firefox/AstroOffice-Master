using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class MapPersKVRequest
    {
        public string Online_Result { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string DD { get; set; } = string.Empty;
        public string MM { get; set; } = string.Empty;
        public string YY { get; set; } = string.Empty;
        public string HH { get; set; } = string.Empty;
        public string Min { get; set; } = string.Empty;
        public string SS { get; set; } = "00";
        public string Username { get; set; } = "admin";
        public string Lon { get; set; } = string.Empty;
        public string Lat { get; set; } = string.Empty;
        public string TZ { get; set; } = string.Empty;
        public bool Paid { get; set; } = true;
        public string Lang { get; set; } = string.Empty;
        public bool ShowRef { get; set; }
        public bool Male { get; set; }
        public string Domain { get; set; } = "YICC";
        public string FilePrefix { get; set; } = "YICC";
        public string VcnPrefix { get; set; } = "YICC";
        public string Source { get; set; } = "YICC";
        public string HeaderTitle { get; set; } = "YICC";
        public string Product { get; set; } = "New Product";
        public string WDD { get; set; } = "01";
        public string WMM { get; set; } = "01";
        public string WYY { get; set; } = "2000";
        public short Rotate { get; set; } = 1;
    }
}
