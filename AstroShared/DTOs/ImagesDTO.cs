using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public class ImagesDTO
    {
        public long Sno { get; set; }
        public long ProductID { get; set; }
        public string? ImageURL { get; set; }
        public string? ImageName { get; set; }
    }
}

