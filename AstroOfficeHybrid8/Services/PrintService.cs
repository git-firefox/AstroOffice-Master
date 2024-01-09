using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;

namespace AstroOfficeHybrid8.Services
{
    public class PrintService  : IPrintService
    {
        public async Task PrintPdfAsync(string base64Data)
        {
            string dataUrl = $"data:application/pdf;base64,{base64Data}";
            byte[] pdfBytes = Convert.FromBase64String(base64Data);


            string tempFilePath = Path.Combine(FileSystem.CacheDirectory, $"kundlai-{DateTime.Today.ToString(format: "dd-MM-yyyy-HH-mm-ss")}.pdf");
            File.WriteAllBytes(tempFilePath, pdfBytes);

    
            await Launcher.OpenAsync(new OpenFileRequest { File = new ReadOnlyFile(tempFilePath, "application/pdf") });

        }

        public void PrintPdf(byte[] pdfBytes)
        {
            throw new NotImplementedException();
        }
    }
}
