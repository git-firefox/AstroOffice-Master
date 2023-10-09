namespace AstroOfficeWeb.Shared.Models
{
    public class BirthDetailsLookups
    {
        public IList<SelectListItem> BirthCategoryItems { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Kamkaj", "0"),
            new SelectListItem("ScoreTY", "1"),
            new SelectListItem("Tool", "2"),
            new SelectListItem("OnlyYogYuti", "3"),
            new SelectListItem("ToolOnlyYogYuti", "4"),
            new SelectListItem("ratna", "5"),
            new SelectListItem("ratnaonly", "6"),
            new SelectListItem("kpcusp", "7"),
            new SelectListItem("tradefair", "8"),
            new SelectListItem("tradefair_upay", "9"),
            new SelectListItem("YICCCOMBO1", "10"),
            new SelectListItem("YICCCOMBO2", "11"),
            new SelectListItem("YICCCOMBO4", "12"),
            new SelectListItem("YICCCOMBO5", "13"),
            new SelectListItem("YICCCOMBO7", "14"),
            new SelectListItem("YICCCOMBO10", "15"),
            new SelectListItem("YICCCOMBO25", "16"),
            new SelectListItem("disease", "17"),
            new SelectListItem("married_life", "18"),
            new SelectListItem("occupation", "19"),
            new SelectListItem("parents", "20"),
            new SelectListItem("santan", "21"),
            new SelectListItem("tool_disease", "22"),
            new SelectListItem("tool_married_life", "23"),
            new SelectListItem("tool_occupation", "24"),
            new SelectListItem("tool_parents", "25"),
            new SelectListItem("tool_santan", "26"),
            new SelectListItem("manglik", "27")
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
