using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Shared.Lookups
{
    public class CmbRotate
    {
        public IList<SelectListItem> Items = new List<SelectListItem>
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
