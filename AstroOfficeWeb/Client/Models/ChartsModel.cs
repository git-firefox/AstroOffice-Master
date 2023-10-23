namespace AstroOfficeWeb.Client.Models
{
    public class ChartHouseTableTRModel : TableAttributeConfiguration
    {
        public int House { get; set; }
        public string? RL_NL_SL_SSL { get; set; }
        public string? NakSigni { get; set; }
        public string? SubSigni { get; set; }
    }

    public class ChartPlanetTableTRModel : TableAttributeConfiguration
    {
        public string? Planet { get; set; }
        public string? RL_NL_SL_SSL { get; set; }
        public string? Significators { get; set; }
    }

}
