
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public enum ProceedStatus
    {
        Billing,
        Shipping,
        Payment,
        Placed
    }
    public partial class ProductCheckout
    {
        private ElementReference ER_SelectCountry { get; set; }
        private ElementReference ER_ABillingInfo { get; set; }
        private ElementReference ER_AShippingInfo { get; set; }
        private ElementReference ER_APaymentInfo { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.LoadSelect2Async(ER_SelectCountry);
            }
        }

        private async Task OnClick_BtnProceed(ProceedStatus status)
        {
            if (status == ProceedStatus.Billing)
            {
                await JSRuntime.ShowTabAsync(ER_ABillingInfo);
            }
            else if (status == ProceedStatus.Shipping)
            {
                await JSRuntime.ShowTabAsync(ER_AShippingInfo);
            }
            else if (status == ProceedStatus.Payment)
            {
                await JSRuntime.ShowTabAsync(ER_APaymentInfo);
            }
        }
        private async Task OnClick_BtnChangeAddress(int type)
        {

        }
    }
}
