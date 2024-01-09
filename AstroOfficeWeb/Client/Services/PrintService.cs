using AstroOfficeWeb.Components;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Services
{
    public class PrintService : IPrintService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly IJSRuntime JSRuntime;
        private readonly NavigationManager NavigationManager;

        public PrintService(ISwaggerApiService swagger, IJSRuntime jSRuntime, NavigationManager navigationManager)
        {
            _swagger = swagger;
            JSRuntime = jSRuntime;
            NavigationManager = navigationManager;
        }

        public void PrintPdf(byte[] pdfBytes)
        {
            throw new NotImplementedException();
        }

        public async Task PrintPdfAsync(string base64Data)
        {
            string dataUrl = $"data:application/pdf;base64,{base64Data}";

            await JSRuntime.OpenDocumentInNewTabAsync("falladesh.pdf", base64Data);
            NavigationManager!.NavigateTo(dataUrl);
        }


        
    }
}
