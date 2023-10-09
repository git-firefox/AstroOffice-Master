using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_data")]
    public partial class ADatum
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("page_keyword", TypeName = "text")]
        public string? PageKeyword { get; set; }
        [Column("page_desc", TypeName = "text")]
        public string? PageDesc { get; set; }
        [Column("page_heading", TypeName = "text")]
        public string? PageHeading { get; set; }
        [Column("page_content", TypeName = "text")]
        public string? PageContent { get; set; }
    }
}
