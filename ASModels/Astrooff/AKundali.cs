using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_Kundalis")]
    public partial class AKundali
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? ProductName { get; set; }
        [StringLength(10)]
        public string? Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        public TimeSpan? TimeOfBirth { get; set; }
        [Column("PlaceOfBirthID")]
        public int? PlaceOfBirthId { get; set; }
        [StringLength(255)]
        public string? Language { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsSaved { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ViewDate { get; set; }
        [Column("A_User_SNO")]
        public long? AUserSno { get; set; }
        [StringLength(255)]
        public string? CountryCode { get; set; }
        [StringLength(255)]
        public string? Category { get; set; }
        [StringLength(255)]
        public string? Ayanansh { get; set; }
        public int? Rotate { get; set; }
        public bool? CheckSahasaneLogic { get; set; }
        public bool? CheckSalaChakkar { get; set; }
        [Column("CheckMFal")]
        public bool? CheckMfal { get; set; }
        public bool? CheckShowRef { get; set; }
        public int? KundaliUdvYear { get; set; }
        [StringLength(255)]
        public string? TimeType { get; set; }
        [StringLength(255)]
        public string? SkipBadType { get; set; }
        public int? TimeValue { get; set; }
        [StringLength(255)]
        public string? PlaceOfBrithSearch { get; set; }

        [ForeignKey("AUserSno")]
        [InverseProperty("AKundalis")]
        public virtual AUser? AUserSnoNavigation { get; set; }
    }
}
