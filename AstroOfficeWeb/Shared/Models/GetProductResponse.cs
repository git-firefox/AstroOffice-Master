using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.ViewModels;

namespace AstroOfficeWeb.Shared.Models
{
    public class GetProductResponse : ApiResponseBase
    {
        public BaseProductDTO GeneralInformation { get; set; } = new();
        public List<MediaFileDTO> ProductMediaFiles { get; set; } = new();
        public List<MetaDataDTO> ProductMetaDatas { get; set; } = new();
    }
}
