using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("new_mix_dasha")]
    public partial class NewMixDasha
    {
        [Key]
        [Column("tid")]
        public int Tid { get; set; }
        [Column("sno")]
        public int Sno { get; set; }
        [Column("ruleno")]
        public int? Ruleno { get; set; }
        [Column("ruleno2")]
        public int? Ruleno2 { get; set; }
        [Column("ruleformula")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? Ruleformula { get; set; }
        [Column("planet1")]
        public int? Planet1 { get; set; }
        [Column("house1")]
        public int? House1 { get; set; }
        [Column("planet2")]
        public int? Planet2 { get; set; }
        [Column("house2")]
        public int? House2 { get; set; }
        [Column("planet3")]
        public int? Planet3 { get; set; }
        [Column("house3")]
        public int? House3 { get; set; }
        [Column("planet4")]
        public int? Planet4 { get; set; }
        [Column("house4")]
        public int? House4 { get; set; }
        [Column("rules")]
        [StringLength(255)]
        public string? Rules { get; set; }
        [Column("pred_hindi")]
        public string? PredHindi { get; set; }
        [Column("pred_english", TypeName = "text")]
        public string? PredEnglish { get; set; }
        [Column("upay")]
        public int? Upay { get; set; }
        [Column("isbad")]
        public bool? Isbad { get; set; }
        [Column("verybad")]
        public bool? Verybad { get; set; }
        [Column("common")]
        public bool? Common { get; set; }
        [Column("male")]
        public bool? Male { get; set; }
        [Column("female")]
        public bool? Female { get; set; }
        [Column("shubh")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Shubh { get; set; }
        [Column("ashubh")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Ashubh { get; set; }
        [Column("empty")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Empty { get; set; }
        [Column("wealth")]
        public bool? Wealth { get; set; }
        [Column("santan")]
        public bool? Santan { get; set; }
        [Column("married_life")]
        public bool? MarriedLife { get; set; }
        [Column("occupation")]
        public bool? Occupation { get; set; }
        [Column("disease")]
        public bool? Disease { get; set; }
        [Column("love_affair")]
        public bool? LoveAffair { get; set; }
        [Column("sibling")]
        public bool? Sibling { get; set; }
        [Column("parents")]
        public bool? Parents { get; set; }
        [Column("family")]
        public bool? Family { get; set; }
        [Column("general")]
        public bool? General { get; set; }
        [Column("nature")]
        public bool? Nature { get; set; }
        [Column("precaution")]
        public bool? Precaution { get; set; }
        [Column("uncle")]
        public bool? Uncle { get; set; }
        [Column("inlaw")]
        public bool? Inlaw { get; set; }
        [Column("travel")]
        public bool? Travel { get; set; }
        [Column("education")]
        public bool? Education { get; set; }
        [Column("age")]
        public bool? Age { get; set; }
        [Column("spl_yog")]
        public bool? SplYog { get; set; }
        [Column("work_pred")]
        public bool? WorkPred { get; set; }
        [Column("signi")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Signi { get; set; }
        [Column("ptype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ptype { get; set; }
        [Column("planet5")]
        public int? Planet5 { get; set; }
        [Column("house5")]
        public int? House5 { get; set; }
        [Column("orplanet")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Orplanet { get; set; }
        [Column("not_orplanet")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NotOrplanet { get; set; }
        [Column("andplanet")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Andplanet { get; set; }
        [Column("not_andplanet")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NotAndplanet { get; set; }
        [Column("yutihouse")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Yutihouse { get; set; }
        [Column("conj")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Conj { get; set; }
        [Column("not_conj")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NotConj { get; set; }
        [Column("drishti")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Drishti { get; set; }
        [Column("not_drishti")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NotDrishti { get; set; }
        [Column("not_empty")]
        [StringLength(100)]
        [Unicode(false)]
        public string? NotEmpty { get; set; }
        [Column("lawtype")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Lawtype { get; set; }
        [Column("ref")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Ref { get; set; }
        [Column("planethouse")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Planethouse { get; set; }
        [Column("yuticombi")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Yuticombi { get; set; }
        [Column("age1")]
        public short? Age1 { get; set; }
        [Column("age2")]
        public short? Age2 { get; set; }
        [Column("created_by")]
        [StringLength(100)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }
        [Column("created_date", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("updated_by")]
        [StringLength(100)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }
        [Column("updated_date", TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; }
        [Column("status_updated_by")]
        [StringLength(100)]
        [Unicode(false)]
        public string? StatusUpdatedBy { get; set; }
        [Column("status_updated_date", TypeName = "datetime")]
        public DateTime? StatusUpdatedDate { get; set; }
        [Column("shubhGhar")]
        public int ShubhGhar { get; set; }
        [Column("mandaGhar")]
        public int MandaGhar { get; set; }
        [Column("kamjorGrah")]
        public int KamjorGrah { get; set; }
        [Column("lagteGhar")]
        [StringLength(255)]
        [Unicode(false)]
        public string? LagteGhar { get; set; }
        [Column("vfal_years")]
        [StringLength(255)]
        [Unicode(false)]
        public string? VfalYears { get; set; }
        [Column("notLagteGhar")]
        [StringLength(255)]
        [Unicode(false)]
        public string? NotLagteGhar { get; set; }
        [Column("tag_id")]
        public int? TagId { get; set; }
        [Column("relevant")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Relevant { get; set; }
    }
}
