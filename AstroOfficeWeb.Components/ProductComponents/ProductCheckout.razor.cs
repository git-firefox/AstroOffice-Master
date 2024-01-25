using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Components.ProductComponents
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
        [Parameter]
        public bool IsDataUrl { get; set; } = false;
        private ViewAddressModal Modal_ViewAddress { get; set; } = null!;

        private ElementReference ER_ABillingInfo { get; set; }
        private ElementReference ER_AShippingInfo { get; set; }
        private ElementReference ER_APaymentInfo { get; set; }

        private BillingInfoViewModel BillingInfo { get; set; } = new();
        private EditContext BillingInfoContext { get; set; } = null!;
        private PlaceOrderViewModel PlaceOrder { get; set; } = new();

        private List<Option> CountryOptions { get; set; } = new();
        private List<AddressDTO>? Addresses { get; set; }
        private List<AddressDTO> ShippingAddresses { get; set; } = new();
        private CreditCard CreditCard { get; set; } = new();
        private PaymentMethod BillingOption { get; set; } = PaymentMethod.CashOnDelivery;



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
            CountryOptions = await CountryService.GetCountryOptionsAsync();
            Addresses = await ProductService.GetUserAddresses();
            CartItems = await ProductService.GetCartItems(IsDataUrl);
            OrderSummary = new(CartItems!.Sum(ci => ci.ProductQuantity * ci.ProductPrice));
        }



        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        private async Task OnClick_BtnProceed(ProceedStatus status)
        {
            if (!BillingInfoContext.Validate())
            {
                await JSRuntime.ShowTabAsync(ER_ABillingInfo);
            }

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
                //await JSRuntime.ShowTabAsync(ER_APaymentInfo);
                //var payment = new StripePayment();
                //await payment.MakePayment(CreditCard.CardNumber, CreditCard.ExpiryMonth, CreditCard.ExpiryYear, CreditCard.CVV);
                //var response = await StripePayment.CreatePaymentIntent(200);
                //StripePayment.CreateCheckoutSession();
                if (BillingOption == PaymentMethod.CashOnDelivery)
                {
                    PlaceOrder.PaymentMethod = BillingOption;
                    //PlaceOrder.ShippingAddressSno = 0;
                    //PlaceOrder.BillingAddressSno = 0;
                    await ProductService.PlaceOrder(PlaceOrder);
                }
                else if (BillingOption == PaymentMethod.Stripe)
                {
                    await ProductService.CreateCheckoutSession();
                }
            }
        }

        private async Task OnSubmit_BillingInfo()
        {
            if (BillingInfoContext.Validate())
            {
                BillingInfo.AddressType = AddressType.Billing;
                await ProductService.SaveUserAddress(BillingInfo);

                PlaceOrder.BillingAddressSno = BillingInfo.Sno;

                if (BillingInfo.ShipToDifferentAddress)
                {
                    ShippingAddresses.Clear();
                    var homeAddress = Addresses?.FirstOrDefault(a => a.AddressType == AddressType.Home);
                    var officeAddress = Addresses?.FirstOrDefault(a => a.AddressType == AddressType.Office);
                    if (homeAddress != null)
                    {
                        ShippingAddresses.Add(homeAddress);
                    }
                    if (officeAddress != null)
                    {
                        ShippingAddresses.Add(officeAddress);
                    }
                    PlaceOrder.ShipToDifferentAddress = true;
                    await JSRuntime.ShowTabAsync(ER_AShippingInfo);
                    PlaceOrder.BillingAddressSno = BillingInfo.Sno;
                    StateHasChanged();
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

        private async Task ProceedCheckoutNavPills(ProceedStatus type)
        {
            if (!BillingInfoContext.Validate())
            {
                await JSRuntime.ShowTabAsync(ER_ABillingInfo);
                //switch (type)
                //{
                //    case ProceedStatus.Billing:
                //        {
                //            await JSRuntime.ShowTabAsync(ER_ABillingInfo);
                //            break;
                //        }

                //    case ProceedStatus.Shipping:
                //        {
                //            await JSRuntime.ShowTabAsync(ER_AShippingInfo);
                //            break;
                //        }

                //    case ProceedStatus.Payment:
                //        {
                //            await JSRuntime.ShowTabAsync(ER_APaymentInfo);
                //            break;
                //        }

                //    case ProceedStatus.Placed:
                //        {

                //            break;
                //        }
                //}
            }
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
            PlaceOrder.BillingAddressSno = address.Sno;
            BillingInfoContext.Validate();
        }
    }
}
