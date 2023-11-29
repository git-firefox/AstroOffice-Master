﻿using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AstroShared.Helper;
using AstroOfficeWeb.Client.Pages.Product;
using Microsoft.AspNetCore.Components.Forms;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class ViewAddressModal
    {
        protected ElementReference ER_ViewAddressModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Address";

        [Parameter]
        public long DefaultAddressSno { get; set; }

        [Parameter]
        public List<CountryDTO> CountryDTOs { get; set; } = new();

        [Parameter]
        public EventCallback<bool> OnConfirmationChanged { get; set; }

        [Parameter]
        public EventCallback<AddressDTO> OnSelectAddressChanged { get; set; }

        [Parameter]
        public List<AddressDTO>? Addresses { get; set; }

        public AddressDTO? BillingInfo { get; set; }

        private AddressDTO SelectedAddress { get; set; } = new();

        private InputText Input_MobileNumber { get; set; } = new();
        private InputText Input_ZipCode { get; set; } = new();
        private InputSelect<long> Input_Country { get; set; } = new();

        protected override void OnInitialized()
        {
            if (Addresses != null && Addresses.Any())
            {
                SelectedAddress = Addresses.First();
            }
            else
            {
                SelectedAddress = new();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.LoadSelect2Async(Input_Country.Element);
                await JSRuntime.ApplyInputMaskAsync(Input_MobileNumber.Element, "999 999 9999");
                await JSRuntime.ApplyInputMaskAsync(Input_ZipCode.Element, "999 999");
            }
        }

        private async Task OnFocusOut_InputPhoneNumber(FocusEventArgs e)
        {
            var mobilenumber = await JSRuntime.GetInputMaskValueAsync(Input_MobileNumber.Element);
            BillingInfo!.PhoneNumber = mobilenumber.ToMobileNumber();
        }

        private async Task OnFocusOut_InputZipCode(FocusEventArgs e)
        {
            var zipcode = await JSRuntime.GetInputMaskValueAsync(Input_ZipCode.Element);
            BillingInfo!.ZipCode = zipcode.ToDigits();
        }

        private async void OnBlur_Country(FocusEventArgs e)
        {
            //var obj = await JSRuntime.GetSelect2DataAsync(Input_Country.Element);
        }

        enum AddressMode
        {
            View,
            Add,
            Edit,
            Delete,
            Select,
            Close
        }

        enum AddressType
        {
            Home,
            Billing,
            Office,
        }

        private AddressMode Mode { get; set; } = AddressMode.View;
        private async Task OnSubmit_UpdateAddress()
        {
            await ProductService.SaveUserAddress(BillingInfo!);
            if (Mode == AddressMode.Add && BillingInfo!.Sno != 0)
            {
                Addresses!.Add(BillingInfo!);
            }
        }

        protected async Task OnConfirmationChange(bool isConfirm)
        {
            BillingInfo = null;
            if (isConfirm)
            {
                await OnSelectAddressChanged.InvokeAsync(SelectedAddress);
            }
        }

        private void OnClick_BtnAddAddress(MouseEventArgs e)
        {
            Mode = AddressMode.Add;
            BillingInfo = new();
        }

        private void OnClick_BtnEditAddress(AddressDTO address)
        {
            Mode = AddressMode.Edit;
            BillingInfo = address;
        }

        private void OnClick_BtnCancel()
        {
            Mode = AddressMode.View;
            BillingInfo = null;
        }

        private void OnClick_LabelSelectAddress(AddressDTO address)
        {
            Mode = AddressMode.Select;
            SelectedAddress = address;
        }

        public async Task ShowAsync()
        {
            Mode = AddressMode.View;
            await JSRuntime.ShowModalAsync(ER_ViewAddressModal);
            StateHasChanged();
        }

        public async Task CloseAsync()
        {
            Mode = AddressMode.Close;
            await JSRuntime.CloseModalAsync(ER_ViewAddressModal);
            StateHasChanged();
        }
    }
}