using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.DTOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class SaveAddressRequest
    {
        public long Sno { get; set; }

        public AddressDTO Address { get; set; } = null!;
    }
}
