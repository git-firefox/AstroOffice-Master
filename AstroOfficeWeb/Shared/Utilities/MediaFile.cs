using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Helper;

namespace AstroOfficeWeb.Shared.Utilities
{
    public class MediaFile
    {
        /// <summary>
        /// Name without extention
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// MediaName with extention
        /// </summary>
        public string MediaName { get; set; } = null!;

        public Stream Stream { get; set; } = null!;
        public string FileDataUrl { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public string MediaType { get; set; } = null!;
    }
}
