using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetMixDashaRequest
    {
        public short Planet { get; set; }
        public short House { get; set; }
        public short FieldNumber { get; set; }
        public string Category { get; set; }
        public string PType { get; set; }

    }
    
}
