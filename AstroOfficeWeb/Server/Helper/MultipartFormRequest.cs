using Newtonsoft.Json;

namespace AstroOfficeWeb.Server.Helper
{
    public class MultipartFormRequest<TRequest>
    {
        public string Data { get; set; } = default!;
        public IFormFileCollection Files { get; set; } = default!;
        public TRequest? DataObject => JsonConvert.DeserializeObject<TRequest>(Data);
    }
}
