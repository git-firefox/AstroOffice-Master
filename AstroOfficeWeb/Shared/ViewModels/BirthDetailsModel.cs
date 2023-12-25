using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;


using System.ComponentModel.DataAnnotations;
namespace AstroOfficeWeb.Shared.ViewModels
{
    public class BirthDetailsModel
    {
        public string CmbCountry { get; set; } = "Ind.";
        public string TxtName { get; set; } = "SHIVA";
        public string CmbSkipBad { get; set; } = "Show All";
        public string CmbTime { get; set; } = "Minute";
        public int? TimeValue { get; set; }

        [Range(1, 31, ErrorMessage = "Date should be between 1 to 31")]
        public int? Dobdd { get; set; } = 12;
        public int? Dobmm { get; set; } = 6;
        public int? Dobyy { get; set; } = 2006;
        public int? Tobhh { get; set; } = 13;
        public int? Tobmm { get; set; } = 25;
        public int? DobSecond { get; set; } = 00;
        public string TxtBirthplace { get; set; } = "Delhi";
        public string BirthCity { get; set; } = string.Empty;
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public string CmbCategory { get; set; } = "Kamkaj";
        public string CmbAyanansh { get; set; } = "KP";
        public string Brief { get; set; } = string.Empty;
        public short CmbRotate { get; set; } = 1;
        public bool SahasaneLogic { get; set; }
        public bool SalaChakkar { get; set; }
        public bool Mfal { get; set; } = false;
        public string Longtitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string CmbLanguage { get; set; } = "Hindi";
        public string TxtTimezone { get; set; } = string.Empty;
        public bool IsShowRef { get; set; }
        public Gender Gender { get; set; }
        public int? KundaliUdvYear { get; set; }
        public List<CountryDTO>? BirthCountries { get; set; }

        public List<string> BirthCategories { get; set; } = new List<string> {
            "Kamkaj",
            "ScoreTY",
            "Tool",
            "OnlyYogYuti",
            "ToolOnlyYogYuti",
            "ratna",
            "ratnaonly",
            "kpcusp",
            "tradefair",
            "tradefair_upay",
            "YICCCOMBO1",
            "YICCCOMBO2",
            "YICCCOMBO4",
            "YICCCOMBO5",
            "YICCCOMBO7",
            "YICCCOMBO10",
            "YICCCOMBO25",
            "disease",
            "married_life",
            "occupation",
            "parents",
            "santan",
            "tool_disease",
            "tool_married_life",
            "tool_occupation",
            "tool_parents",
            "tool_santan",
            "manglik"
        };

        public List<string> BirthSkipBadList { get; set; } = new List<string>
        {
             "Show All",
             "Skip Average",
             "Skip Bad",
             "Skip Worst"
        };

        public List<string> BirthTimeList { get; set; } = new List<string>
        {
              "Minute",
              "Hour",
              "Day",
              "Lagan"
        };

        public List<string> AyananshList { get; set; } = new List<string>
        {
            "KP",
            "Lahiri"
        };

        public List<string> LanguageList { get; set; } = new List<string>
        {
            "Hindi",
            "English",
            "Tamil",
            "Bangla",
            "Telugu",
            "Kannada",
            "Marathi",
            "Gujarati",
            "Punjabi",
            "Oriya",
            "Malayalam",
            "Assamese"
        };
    }
}
