

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace AstroOfficeWeb.Client.Services
{
    public class Text7PdfService
    {
        public byte[] GeneratePDF()
        {
            //Document document = new Document();
            using MemoryStream ms = new MemoryStream();
            using var pdfDoc = new PdfDocument(new PdfWriter(ms));
            using var document = new Document(pdfDoc);
            // Add content to the PDF
            document.Add(new Paragraph("Hello, iText 7!"));

            // Close the Document (this will also close the PDF document)
            // document.Close();

            return ms.ToArray();
        }
    }
}
