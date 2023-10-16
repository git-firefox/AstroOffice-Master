using System.Text;
using AstroOfficeWeb.Shared.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IConverter _converter;

        public PdfController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpPost]
        public IActionResult GeneratePDF([FromBody] GeneratePDFRequest request)
        {
            string falla = request.Falla;
            string imgBhavChalit = request.ImgBhavChalit;
            string imgLagan = request.ImgLagan;

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


            var pdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings() { Top = 10, Left = 10, Right = 10 },
                    ColorMode = ColorMode.Color,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = html.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" },
                        FooterSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                    }
                }

            };

            var bytes = _converter.Convert(pdfDocument);

            return Ok(new ApiResponse<string>() { Data = Convert.ToBase64String(bytes), Success = true });
        }
    }
}
