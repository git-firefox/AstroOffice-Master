using AstroOfficeWeb.Shared.Utilities;


namespace AstroOfficeWeb.Shared.ViewModels
{
    public class BirthDetailsLookups
    {
        public IList<SelectListItem> BirthCategoryItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Vyavsaay","Kamkaj"),
            new SelectListItem("Shaadi ke yog","ScoreTY"),
            new SelectListItem("Presant file","Tool"),
            new SelectListItem("Vishesh yog yuti","OnlyYogYuti"),
            new SelectListItem("Vivran yog yuti","ToolOnlyYogYuti"),
            new SelectListItem("Vyakhya ratna","Ratna"),
            new SelectListItem("Shubhratan","Ratnaonly" , true),
            new SelectListItem("Kpcusp","Kpcusp", true),
            new SelectListItem("Kundali without remedy","Tradefair"),
            new SelectListItem("Only savdhaniya","Tradefair_upay"),
            new SelectListItem("One year kundali","YICCCOMBO1"),
            new SelectListItem("Two year kundali","YICCCOMBO2",true),
            new SelectListItem("Four year kundali","YICCCOMBO4",true),
            new SelectListItem("Five year kundali","YICCCOMBO5",true),
            new SelectListItem("Seven year kundali","YICCCOMBO7",true),
            new SelectListItem("Ten year kundali","YICCCOMBO10",true),
            new SelectListItem("Twenty five years kundali","YICCCOMBO25",true),
            new SelectListItem("Health kundali with upay","Disease",true),
            new SelectListItem("Vivah ki kundali with upay","Married_life",true),
            new SelectListItem("Kaamkaaj ki kundali with upay","Occupation",true),
            new SelectListItem("Mata pita ke sukh ki kundali with upay","Parents",true),
            new SelectListItem("Bachhe ke sukh ki kundali with upay","Santan",true),
            new SelectListItem("Health kundali WU","Tool_disease"),
            new SelectListItem("Vivah ki kundali WU","Tool_married_life"),
            new SelectListItem("Kaamkaaj ki kundali WU","Tool_occupation"),
            new SelectListItem("Mata pita ke sukh ki kundali WU","Tool_parents"),
            new SelectListItem("Bachhe ke sukh ki kundali WU","Tool_santan"),
            new SelectListItem("Manglik dosh","Manglik")
        };

        public IList<SelectListItem> SkipBadItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Show All", "0"),
            new SelectListItem("Skip Average", "1"),
            new SelectListItem("Skip Bad", "2"),
            new SelectListItem("Skip Worst", "3")
        };

        public IList<SelectListItem> CmbTimeItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Minute", "0"),
            new SelectListItem("Hour", "1"),
            new SelectListItem("Day", "2"),
            new SelectListItem("Lagan", "3")
        };

        public List<SelectListItem> CmbAyananshItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("KP", "0"),
            new SelectListItem("Lahiri", "1")
        };

        public List<SelectListItem> LanguageItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Hindi", "0"),
            new SelectListItem("English", "1"),
            new SelectListItem("Tamil", "2"),
            new SelectListItem("Bangla", "3"),
            new SelectListItem("Telugu", "4"),
            new SelectListItem("Kannada", "5"),
            new SelectListItem("Marathi", "6"),
            new SelectListItem("Gujarati", "7"),
            new SelectListItem("Punjabi", "8"),
            new SelectListItem("Oriya", "9"),
            new SelectListItem("Malayalam", "10"),
            new SelectListItem("Assamese", "11")
        };

        public IList<SelectListItem> CmbRotateItems = new List<SelectListItem>
        {
            new SelectListItem("1", "0"),
            new SelectListItem("2", "1"),
            new SelectListItem("3", "2"),
            new SelectListItem("4", "3"),
            new SelectListItem("5", "4"),
            new SelectListItem("6", "5"),
            new SelectListItem("7", "6"),
            new SelectListItem("8", "7"),
            new SelectListItem("9", "8"),
            new SelectListItem("10", "9"),
            new SelectListItem("11", "10"),
            new SelectListItem("12", "11")
        };

    }
}
