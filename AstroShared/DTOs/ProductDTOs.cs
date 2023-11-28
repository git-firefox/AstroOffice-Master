using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public abstract class ProductDTOBase
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 1_000_000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 100, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Upload atleast 1 image.")]
      //  [MinLength(1, ErrorMessage = "Upload atleast 1 image.")]
        [MaxLength(10, ErrorMessage = "Can only upload max 10 images.")]
        public List<string> FileNames { get; set; } = new List<string>();
    }
    public class ViewProductDTO : ProductDTOBase
    {
        public long Sno { get; set; }
        public List<ImagesDTO>? ProductImages { get; set; }
    }

    public class SaveProductDTO : ProductDTOBase
    {
        public List<ImagesDTO>? ProductImages { get; set; }
    }
}
