using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class ApiErrorResponse
    {
        public string Type { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int Status { get; set; }
        public string TraceId { get; set; } = null!;
        public Dictionary<string, string[]> Errors { get; set; } = null!;
    }
}
