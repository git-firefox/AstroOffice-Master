using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class MetaDataDTO
    {
        public long Sno { get; set; }
        [Required]
        public string? MetaValue { get; set; } = string.Empty;
        [Required]
        public string? MetaKeyword { get; set; } = string.Empty;
        public string? MetaDescription { get; set; }
    }

}
