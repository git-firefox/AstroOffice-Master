using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Services
{
    public class DocumentService
    {
        private readonly ISwaggerApiService _swagger;

        public DocumentService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
        }

        public async Task<string> ExportKundaliToPdf(string? htmlStringFalla, string? imgSrcBhavChalit, string? imgSrcLagan)
        {
            var request = new GeneratePDFRequest()
            {
                Falla = htmlStringFalla ?? "",
                ImgBhavChalit = imgSrcBhavChalit ?? "",
                ImgLagan = imgSrcLagan ?? ""
            };
            //string dataUrl = $"data:application/pdf;base64,{base64Data}";
            var response = await _swagger.PostAsync<GeneratePDFRequest, ApiResponse<string>>(DocumentApiConst.POST_ExportKundaliToPdf, request);
            if (response == null) return "";
            return response.Data ?? "";
        }
    }
}
