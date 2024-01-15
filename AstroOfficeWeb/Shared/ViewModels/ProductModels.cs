using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.ViewModels
{

    public class ListViewItemProductModel
    {
        public IEnumerable<BaseViewProductDTO>? Products { get; set; }
    }

    public class ViewProductModel : BaseViewProductDTO { }

    public class ProductGeneralInformationModel
    {
        public BaseProductDTO ProductDTO { get; set; }
    }

    public class ProductMediaFilesModel
    {
        public List<MediaFileDTO> MediaDTOs { get; set; } = null!;

        [Required(ErrorMessage = "Please select a file.")]
        [MinLength(1, ErrorMessage = "Upload atleast 1 image.")]
        [MaxLength(10, ErrorMessage = "Can only upload max 10 images.")]
        public List<string> FileNames { get; set; } = new();
    }

    public class ProductMetaDatasModel
    {
        public List<MetaDataDTO> MetaDatas { get; set; } = null!;
    }
}
