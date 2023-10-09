using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class AUserDTO
    {
        public string? UserName { get; set; }
        public bool CanAddNew { get; set; }
        public bool CanModify { get; set; }
        public bool CanReport { get; set; }
        public long ActiveUserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
