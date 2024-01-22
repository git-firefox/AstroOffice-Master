using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;

namespace AstroOfficeWeb.Shared.Models
{
    public class SaveProductRequest 
    {
        public long Sno { get; set; }
        public BaseProductDTO GeneralInformation { get; set; } = new();
        public List<MediaFileDTO> ProductMediaFiles { get; set; } = new();
        public List<MetaDataDTO> ProductMetaDatas { get; set; } = new();
    }
}
