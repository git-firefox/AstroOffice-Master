using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AstroOfficeWeb.Shared.SSExpertSystem.Models
{
    [XmlRoot("SingleSmsApiModel")]
    public class SendOtpRequest
    {
        [XmlElement("SenderId")]
        public string? SenderId { get; set; }

        [XmlElement("Message")]
        public string? Message { get; set; }

        [XmlElement("MobileNumbers")]
        public string? MobileNumbers { get; set; }

        [XmlElement("ApiKey")]
        public string? ApiKey { get; set; }

        [XmlElement("ClientId")]
        public string? ClientId { get; set; }
    }
}
