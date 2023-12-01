using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ProductOrder
    {
        public ProductOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public long Sno { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalAmount { get; set; }
        [StringLength(50)]
        public string? PaymentMethod { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Status { get; set; }
        [Column("ShippingAddress_Sno")]
        public long? ShippingAddressSno { get; set; }
        [Column("BillingAddress_Sno")]
        public long? BillingAddressSno { get; set; }
        [Column("A_Users_Sno")]
        public long? AUsersSno { get; set; }

        [ForeignKey("AUsersSno")]
        [InverseProperty("ProductOrders")]
        public virtual AUser? AUsersSnoNavigation { get; set; }
        [ForeignKey("BillingAddressSno")]
        [InverseProperty("ProductOrderBillingAddressSnoNavigations")]
        public virtual Address? BillingAddressSnoNavigation { get; set; }
        [ForeignKey("ShippingAddressSno")]
        [InverseProperty("ProductOrderShippingAddressSnoNavigations")]
        public virtual Address? ShippingAddressSnoNavigation { get; set; }
        [InverseProperty("ProductOrdersSnoNavigation")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
