using AstroOfficeWeb.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class MediaDTO
    {
        public long Sno { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaName { get; set; }
        public string? MediaType { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public FileData? Attachment { get; set; }
    }

}
