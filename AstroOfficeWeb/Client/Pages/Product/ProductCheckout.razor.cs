
using AstroOfficeWeb.Client.Services;
using AstroOfficeWeb.Client.Shared;
using AstroOfficeWeb.Client.Shared.CustomInputs;
using AstroOfficeWeb.Shared.Models;
using AstroShared;
using AstroShared.DTOs;
using AstroShared.Helper;
using AstroShared.Utilities;
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

    public class PlaceOrderViewModel : PlaceOrderRequest
    {

    }

    public class CreditCard
    {
        public string CardNumber { get; set; } = null!;
        public string CardHolderName { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; } = null!;

        public string ExpiryMonth
        {
            get
            {
                return ExpiryDate.ToString(format: "MM");
            }
        }
        public string ExpiryYear
        {
            get
            {
                return ExpiryDate.ToString(format: "yyyy");
            }
        }

    }

    public partial class ProductCheckout
    {
        private ViewAddressModal Modal_ViewAddress { get; set; } = null!;

        private ElementReference ER_ABillingInfo { get; set; }
        private ElementReference ER_AShippingInfo { get; set; }
        private ElementReference ER_APaymentInfo { get; set; }

        private BillingInfoViewModel BillingInfo { get; set; } = new();
        private EditContext BillingInfoContext { get; set; } = null!;
        private PlaceOrderViewModel PlaceOrder { get; set; } = new();

        private List<Option> CountryOptions { get; set; } = new();
        private List<AddressDTO>? Addresses { get; set; }
        private CreditCard CreditCard { get; set; } = new();



        protected override void OnInitialized()
        {
            base.OnInitialized();

            BillingInfoContext = new EditContext(BillingInfo);
        }

        private List<CartItemDTO>? CartItems { get; set; }
        private CalculateOrderSummary OrderSummary { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CountryOptions = await GetCountryOptionsAsync();
            Addresses = await ProductService.GetUserAddresses();
            CartItems = await ProductService.GetCartItems();
            OrderSummary = new(CartItems!.Sum(ci => ci.ProductQuantity * ci.ProductPrice));
        }

        private async Task<List<Option>> GetCountryOptionsAsync()
        {
            var countryDTOs = await Swagger.GetAsync<List<CountryDTO>>(CountryApiConst.GET_Countries) ?? new List<CountryDTO>();

            var options = countryDTOs.Select(a => new Option { Text = a.Country, Value = a.Sno }).ToList();
            return options;
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        private async Task OnClick_BtnProceed(ProceedStatus status)
        {
            if (status == ProceedStatus.Billing)
            {
                await JSRuntime.ShowTabAsync(ER_ABillingInfo);
            }
            else if (status == ProceedStatus.Shipping)
            {
                PlaceOrder.ShipToDifferentAddress = true;
                await JSRuntime.ShowTabAsync(ER_AShippingInfo);
            }
            else if (status == ProceedStatus.Payment)
            {
                //await JSRuntime.ShowTabAsync(ER_APaymentInfo);
                //var payment = new StripePayment();
                //await payment.MakePayment(CreditCard.CardNumber, CreditCard.ExpiryMonth, CreditCard.ExpiryYear, CreditCard.CVV);
                //var response = await StripePayment.CreatePaymentIntent(200);
                //StripePayment.CreateCheckoutSession();
                //await ProductService.PlaceOrder(PlaceOrder);
                await ProductService.CreateCheckoutSession();
            }
        }

        private async Task OnSubmit_BillingInfo()
        {
            if (BillingInfoContext.Validate())
            {
                if (string.IsNullOrEmpty(BillingInfo.AddressType))
                {
                    BillingInfo.AddressType = ProceedStatus.Billing.ToString();
                }

                await ProductService.SaveUserAddress(BillingInfo);

                PlaceOrder.BillingAddressSno = BillingInfo.Sno;

                if (BillingInfo.ShipToDifferentAddress)
                {
                    PlaceOrder.ShipToDifferentAddress = true;
                    await JSRuntime.ShowTabAsync(ER_AShippingInfo);
                    PlaceOrder.BillingAddressSno = BillingInfo.Sno;
                }
                else
                {
                    PlaceOrder.ShipToDifferentAddress = false;
                    PlaceOrder.BillingAddressSno = BillingInfo.Sno;
                    await JSRuntime.ShowTabAsync(ER_APaymentInfo);
                }
            }
        }

        private async Task OnClick_BtnChangeAddress(int type)
        {
            await Modal_ViewAddress.ShowAsync();
        }

        private void OnSelect_Address(AddressDTO address)
        {
            BillingInfo.Sno = address.Sno;
            BillingInfo.ACountrySno = address.ACountrySno;
            BillingInfo.AddressType = address.AddressType;
            BillingInfo.FirstName = address.FirstName;
            BillingInfo.LastName = address.LastName;
            BillingInfo.AddressLine1 = address.AddressLine1;
            BillingInfo.AddressLine2 = address.AddressLine2;
            BillingInfo.City = address.City;
            BillingInfo.State = address.State;
            BillingInfo.ZipCode = address.ZipCode;
            BillingInfo.Landmark = address.Landmark;
            BillingInfo.Email = address.Email;
            BillingInfo.Country = address.Country;
            BillingInfo.PhoneNumber = address.PhoneNumber;
        }
    }
}
