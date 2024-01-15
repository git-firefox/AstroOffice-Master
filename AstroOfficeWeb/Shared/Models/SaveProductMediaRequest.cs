using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.Models
{
    public class SaveProductMediaRequest
    {
        public List<MediaFile> File { get; set; } = null!;
    }
}
