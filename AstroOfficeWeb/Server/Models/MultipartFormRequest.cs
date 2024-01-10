using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace AstroOfficeWeb.Server.Models
{
    public class MultipartFormRequest<TRequest>
    {
        public JObject Data { get; set; } = default!;
        public IFormFileCollection Files { get; set; } = default!;

        public TRequest? GetDataObject() => this.Data.ToObject<TRequest>();
    }
}
