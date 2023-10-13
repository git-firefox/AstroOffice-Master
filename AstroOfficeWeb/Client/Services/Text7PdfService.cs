using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace AstroOfficeWeb.Client.Services
{
    public class Text7PdfService
    {
        public byte[] GeneratePDF(string? falla, string? imgBhavChalit, string? imgLagan)
        {
            //Document document = new Document();
            //using var ms = new MemoryStream();
            //using var pdfDoc = new PdfDocument(new PdfWriter(ms));
            //using var document = new Document(pdfDoc);
            // Add content to the PDF

            var html = new StringBuilder();

            html.Append("<!DOCTYPE html>")
                .Append("<html lang='en'>")
                .Append("<head>")
                .Append("<meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>")
                .Append("<title>Document</title>")
                .Append("<style>")
                .Append(".content { font-size: 20px; word-wrap: break-word; white-space: pre-wrap; word-wrap: break-word; }")
                .Append(".image-table { width: 100%; }")
                .Append(".image-table th, .image-table td { padding: 10px; }")
                .Append("fieldset { text-align: center; font-size: 20px; }")
                .Append("img { display: block; margin: 0 auto; padding: 10px; }")
                .Append("</style>")
                .Append("</head>")
                .Append("<body>")
                .Append("<table class='image-table'>")
                .Append("<tr>")
                .Append("<td>")
                .AppendFormat("<fieldset><legend>भाव चलित</legend><img src='{0}' alt='भाव चलित'></fieldset>", imgBhavChalit)
                .Append("</td>")
                .Append("<td>")
                .AppendFormat("<fieldset><legend>लगन</legend><img src='{0}' alt='लगन'></fieldset>", imgLagan)
                .Append("</td>")
                .Append("</tr>")
                .Append("</table>")
                .AppendFormat("<pre class='content'> {0} </pre>", falla)
                .Append("</body>")
                .Append("</html>");

            using MemoryStream memoryStream = new MemoryStream();

            // Create a new PDF document with A4 page size
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(memoryStream));
            pdfDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);

            // Create a document
            Document document = new Document(pdfDoc);

            // Add content to the PDF
            document.Add(new Paragraph("PDF created in memory"));

            // Close the document
            document.Close();


            //document.Add(new Paragraph("Hello, iText 7!"));
            //document.Close();
            return memoryStream.ToArray() ;
        }
    }
}
