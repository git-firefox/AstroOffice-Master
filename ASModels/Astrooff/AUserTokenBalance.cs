using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_UserTokenBalances")]
    [Index("AUserSno", Name = "UQ__A_UserTo__D5FFE1C0BF0CB889", IsUnique = true)]
    public partial class AUserTokenBalance
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("A_User_SNO")]
        public long? AUserSno { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TokenBalance { get; set; }

        [ForeignKey("AUserSno")]
        [InverseProperty("AUserTokenBalance")]
        public virtual AUser? AUserSnoNavigation { get; set; }
    }
}
