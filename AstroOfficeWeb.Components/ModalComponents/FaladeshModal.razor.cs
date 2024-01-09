using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Components.ModalComponents
{
    public partial class FaladeshModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter] public string? BhavChalitSrc { get; set; }
        [Parameter] public string? LaganSrc { get; set; }
        [Parameter] public string? Kundali { get; set; }

        async Task OnClick_BtnPrint(MouseEventArgs args)
        {
            string data = await Document.ExportKundaliToPdf(Kundali, BhavChalitSrc, LaganSrc);
            await Print.PrintPdfAsync(data);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
