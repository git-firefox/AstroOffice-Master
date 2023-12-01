using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_Products")]
    public partial class AProduct
    {
        public AProduct()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
            ProductImages = new HashSet<ProductImage>();
            ProductMetaData = new HashSet<ProductMetaData>();
            ProductWishlists = new HashSet<ProductWishlist>();
        }

        [Key]
        public long Sno { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        [Column("AddedBy_A_Users_Sno")]
        public long AddedByAUsersSno { get; set; }
        [Column("ModifiedBy_A_Users_Sno")]
        public long? ModifiedByAUsersSno { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [InverseProperty("AProductsSnoNavigation")]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [InverseProperty("AProductsSnoNavigation")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [InverseProperty("AProductsSnoNavigation")]
        public virtual ICollection<ProductMetaData> ProductMetaData { get; set; }
        [InverseProperty("AProductsSnoNavigation")]
        public virtual ICollection<ProductWishlist> ProductWishlists { get; set; }
    }
}
