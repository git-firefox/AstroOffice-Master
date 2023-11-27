using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class AddressDTO
    {
        public long Sno { get; set; }
        public string? AddressType { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Landmark { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ACountrySno { get; set; }
    }
}
