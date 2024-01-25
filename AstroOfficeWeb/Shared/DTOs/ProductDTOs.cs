using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.BaseModels;
using AstroOfficeWeb.Shared.Utilities;


namespace AstroOfficeWeb.Shared.DTOs
{
    public class ProductDTO
    {

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 1_000_000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 9999, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int StockQuantity { get; set; }
        public int ProductQuantity { get; set; }

        public string? ImageUrl { get; set; }
        public long ProductCategoriesSno { get; set; }
        public string ProductCategory { get; set; } = null!;
        public DateTime? AddedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        //  [Required(ErrorMessage = "Upload atleast 1 image.")]
        ////  [MinLength(1, ErrorMessage = "Upload atleast 1 image.")]
        //  [MaxLength(10, ErrorMessage = "Can only upload max 10 images.")]
        public List<string> FileNames { get; set; } = new List<string>();


        [StringLength(255, ErrorMessage = "Summary must be at most 255 characters.")]
        public string? Summary { get; set; }

        [StringLength(255, ErrorMessage = "Reference must be at most 255 characters.")]
        public string? Reference { get; set; }

        [StringLength(255, ErrorMessage = "Comment must be at most 255 characters.")]
        public string? Comment { get; set; }

        public ProductStatus Status { get; set; }

        public long Sno { get; set; }
        public List<ImagesDTO>? ProductImages { get; set; }

        public List<MetaDataDTO> MetaDatas { get; set; }

    }
    public class ViewProductDTO : ProductDTO
    {
        //public List<ImagesDTO>? ProductImages { get; set; }
    }

    public class SaveProductDTO : ProductDTO
    {
        //public List<ImagesDTO>? ProductImages { get; set; }
    }


    public class BaseProductDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 1_000_000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 9999, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [Range(1, 1_000_000, ErrorMessage = "Please select Category")]
        public long ProductCategoriesSno { get; set; }


        [Required]
        [StringLength(255, ErrorMessage = "Summary must be at most 255 characters.")]
        public string? Summary { get; set; }


        [StringLength(255, ErrorMessage = "Reference must be at most 255 characters.")]
        public string? Reference { get; set; }


        [StringLength(255, ErrorMessage = "Comment must be at most 255 characters.")]
        public string? Comment { get; set; }

        public ProductStatus Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int ProductQuantity { get; set; }
        public string? ProductCategory { get; set; }
    }

    public class BaseViewProductDTO : BaseProductDTO
    {
        public long Sno { get; set; }
    }

    public class MediaFileDTO : BaseFormFile
    {
        public long Sno { get; set; }
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;
        public string MediaName { get; set; } = null!;
        public string MediaUrl { get; set; } = null!;
        public string MediaType { get; set; } = null!;
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
