using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_house_details")]
    public partial class AHouseDetail
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("hcode")]
        public int? Hcode { get; set; }
        [Column("quality", TypeName = "text")]
        public string? Quality { get; set; }
        [Column("power", TypeName = "text")]
        public string? Power { get; set; }
        [Column("home", TypeName = "text")]
        public string? Home { get; set; }
        [Column("things", TypeName = "text")]
        public string? Things { get; set; }
        [Column("direction", TypeName = "text")]
        public string? Direction { get; set; }
        [Column("animal", TypeName = "text")]
        public string? Animal { get; set; }
        [Column("relative", TypeName = "text")]
        public string? Relative { get; set; }
        [Column("plants", TypeName = "text")]
        public string? Plants { get; set; }
        [Column("place", TypeName = "text")]
        public string? Place { get; set; }
        [Column("bodypart", TypeName = "text")]
        public string? Bodypart { get; set; }
    }
}
