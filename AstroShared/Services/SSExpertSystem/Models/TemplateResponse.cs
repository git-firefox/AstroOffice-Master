using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Services.SSExpertSystem.Models
{
    public class TemplateResponse
    {
        public int TemplateId { get; set; }
        public int CompanyId { get; set; }
        public string? TemplateName { get; set; }
        public string? MessageTemplate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public string? ProductName { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreateDateString { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string? ApprovedDateString { get; set; }
        public string? DltTemplateId { get; set; }
    }
}
