using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Services.IServices
{
    public interface IPrintService
    {
        void PrintPdf(byte[] pdfBytes);
        Task PrintPdfAsync(string base64Data);
    }
}
