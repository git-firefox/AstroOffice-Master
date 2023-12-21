using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Utilities;

namespace AstroOfficeWeb.Shared.Models
{
    public class SaveProductMediaRequest
    {
        public List<FileData> File { get; set; } = null!;
    }
}
