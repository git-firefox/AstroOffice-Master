using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ProductImage
    {
        [Key]
        public long Sno { get; set; }
        [Column("ProductID")]
        public long? ProductId { get; set; }
        [Column("ImageURL")]
        public string? ImageUrl { get; set; }
        [StringLength(255)]
        public string? ImageName { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductImages")]
        public virtual AProduct? Product { get; set; }
    }
}
