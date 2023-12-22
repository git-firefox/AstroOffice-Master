using AstroShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.ComponentModels
{
    public class CategoryDialoge : CategoryDTO
    {
        public string FileUpload { get; set; }
        public string ParentCategory { get; set; } = string.Empty;
        public int TotalEarning { get; set; } = 0;
    }
}
