using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            AProducts = new HashSet<AProduct>();
            InverseParentCategorySnoNavigation = new HashSet<ProductCategory>();
        }

        [Key]
        public long Sno { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        [Column("ImageURL")]
        public string? ImageUrl { get; set; }
        [Column("ParentCategory_Sno")]
        public long? ParentCategorySno { get; set; }
        public string? Descriptions { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        [Column("AddedBy_A_Users_Sno")]
        public long? AddedByAUsersSno { get; set; }
        [Column("ModifiedBy_A_Users_Sno")]
        public long? ModifiedByAUsersSno { get; set; }

        [ForeignKey("AddedByAUsersSno")]
        [InverseProperty("ProductCategoryAddedByAUsersSnoNavigations")]
        public virtual AUser? AddedByAUsersSnoNavigation { get; set; }
        [ForeignKey("ModifiedByAUsersSno")]
        [InverseProperty("ProductCategoryModifiedByAUsersSnoNavigations")]
        public virtual AUser? ModifiedByAUsersSnoNavigation { get; set; }
        [ForeignKey("ParentCategorySno")]
        [InverseProperty("InverseParentCategorySnoNavigation")]
        public virtual ProductCategory? ParentCategorySnoNavigation { get; set; }
        [InverseProperty("ProductCategoriesSnoNavigation")]
        public virtual ICollection<AProduct> AProducts { get; set; }
        [InverseProperty("ParentCategorySnoNavigation")]
        public virtual ICollection<ProductCategory> InverseParentCategorySnoNavigation { get; set; }
    }
}
