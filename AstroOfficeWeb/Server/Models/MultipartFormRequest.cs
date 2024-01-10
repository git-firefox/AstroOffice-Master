using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AstroOfficeWeb.Server.Models
{
    public class MultipartFormRequest<TRequest>
    {
        public string Data { get; set; } = default!;
        public IFormFileCollection Files { get; set; } = default!;
        public TRequest? DataObject => JsonConvert.DeserializeObject<TRequest>(Data);
    }
}
