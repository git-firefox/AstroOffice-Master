namespace AstroOfficeWeb.Client.Models
{
    public class TableAttributeConfiguration
    {
        public string? SelectedClass { get; set; }
        public string? ForeColor { get; set; }
        public string? ToolTipText { get; set; }
    }

    public class MahadashaTableTRModel : TableAttributeConfiguration
    {

        public string? Planet { get; set; }
        public string? Period { get; set; }
        public string? Signi { get; set; }
    }

    public class Years35TableTRModel : TableAttributeConfiguration
    {
        public string? Planet { get; set; }
        public string? Antar { get; set; }
        public string? Period { get; set; }
        public string? Age { get; set; }
    }

    public class AntardashaTableTRModel : TableAttributeConfiguration
    {
        public string? Planet { get; set; }
        public string? Period { get; set; }
        public string? Signi { get; set; }
    }

    public class PrayantardashaTableTRModel : TableAttributeConfiguration
    {
        public string? Planet { get; set; }
        public string? Period { get; set; }
        public string? Signi { get; set; }
    }

    public class SukhsmadashaTableTRModel : TableAttributeConfiguration
    {
        public string? Planet { get; set; }
        public string? Period { get; set; }
        public string? Signi { get; set; }
    }
}


