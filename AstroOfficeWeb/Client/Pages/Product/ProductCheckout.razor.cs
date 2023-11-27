
using AstroOfficeWeb.Client.Shared;
using AstroShared.DTOs;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Client.Pages.Product
{
    public enum ProceedStatus
    {
        Billing,
        Shipping,
        Payment,
        Placed
    }

    public class BillingInfoViewModel : AddressDTO
    {
        public bool ShipToDifferentAddress { get; set; }
        public string? OrderNotes { get; set; }
    }

    public partial class ProductCheckout
    {
        private ViewAddressModal Modal_ViewAddress { get; set; } = null!;

        private InputText Input_MobileNumber { get; set; } = null!;
        private InputText Input_ZipCode { get; set; } = null!;

        private ElementReference ER_SelectCountry { get; set; }
        private ElementReference ER_ABillingInfo { get; set; }
        private ElementReference ER_AShippingInfo { get; set; }
        private ElementReference ER_APaymentInfo { get; set; }

        private BillingInfoViewModel BillingInfo { get; set; } = new();
        private EditContext BillingInfoContext { get; set; } = null!;

        private List<CountryDTO> CountryDTOs { get; set; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            BillingInfoContext = new EditContext(BillingInfo);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CountryDTOs = await GetCountriesAsync();
        }

        private async Task<List<CountryDTO>> GetCountriesAsync()
        {
            return await Swagger.GetAsync<List<CountryDTO>>(CountryApiConst.GET_Countries) ?? new List<CountryDTO>();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.LoadSelect2Async(ER_SelectCountry);
                await JSRuntime.ApplyInputMaskAsync(Input_MobileNumber.Element, "999 999 9999");
                await JSRuntime.ApplyInputMaskAsync(Input_ZipCode.Element, "999 999");
            }
        }

        private async Task OnFocusOut_InputPhoneNumber(FocusEventArgs e)
        {
            var mobilenumber = await JSRuntime.GetInputMaskValueAsync(Input_MobileNumber.Element);
            BillingInfo.PhoneNumber = mobilenumber.ToMobileNumber();
            BillingInfoContext.NotifyFieldChanged(FieldIdentifier.Create(() => BillingInfo.PhoneNumber));
            StateHasChanged();
        }

        private async Task OnFocusOut_InputZipCode(FocusEventArgs e)
        {
            var zipcode = await JSRuntime.GetInputMaskValueAsync(Input_ZipCode.Element);
            BillingInfo.ZipCode = zipcode.ToDigits();
            BillingInfoContext.NotifyFieldChanged(FieldIdentifier.Create(() => BillingInfo.ZipCode));
            StateHasChanged();
        }

        private async Task OnClick_BtnProceed(ProceedStatus status)
        {
            if (BillingInfoContext.Validate())
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
        }

        private async Task OnSubmit_BillingInfo()
        {
            if (BillingInfoContext.Validate())
            {
                BillingInfo.Sno = 1;
                BillingInfo.AddressType = ProceedStatus.Billing.ToString();
                await ProductService.SaveUserAddress(BillingInfo);
                if (BillingInfo.ShipToDifferentAddress)
                {
                    await JSRuntime.ShowTabAsync(ER_AShippingInfo);
                }
                else 
                {
                    await JSRuntime.ShowTabAsync(ER_APaymentInfo);
                }
            }
        }

        private async Task OnClick_BtnChangeAddress(int type)
        {
            await Modal_ViewAddress.ShowAsync();
        }
    }
}
