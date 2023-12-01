using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class OrderItem
    {
        [Key]
        public long Sno { get; set; }
        public int? Quantity { get; set; }
        [Column("ProductOrders_Sno")]
        public long? ProductOrdersSno { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("OrderItems")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
        [ForeignKey("ProductOrdersSno")]
        [InverseProperty("OrderItems")]
        public virtual ProductOrder? ProductOrdersSnoNavigation { get; set; }
    }
}
