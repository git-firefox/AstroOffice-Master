using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_users")]
    public partial class AUser
    {
        public AUser()
        {
            ACcavenueTransactions = new HashSet<ACcavenueTransaction>();
            AKundalis = new HashSet<AKundali>();
            ATokenTransactions = new HashSet<ATokenTransaction>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("username")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("password")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("adminuser")]
        public bool? Adminuser { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanReport { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [StringLength(50)]
        public string? MobileNumber { get; set; }
        [StringLength(6)]
        public string? MobileOtp { get; set; }

        [InverseProperty("AUserSnoNavigation")]
        public virtual AUserTokenBalance? AUserTokenBalance { get; set; }
        [InverseProperty("AUserSnoNavigation")]
        public virtual ICollection<ACcavenueTransaction> ACcavenueTransactions { get; set; }
        [InverseProperty("AUserSnoNavigation")]
        public virtual ICollection<AKundali> AKundalis { get; set; }
        [InverseProperty("AUserSnoNavigation")]
        public virtual ICollection<ATokenTransaction> ATokenTransactions { get; set; }
        [InverseProperty("AUsersSnoNavigation")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
