

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MudBlazor;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.Helper;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ViewAddressModal
    {
        protected ElementReference ER_ViewAddressModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Address";

        [Parameter]
        public long DefaultAddressSno { get; set; }

        [Parameter]
        public List<Option> CountryOptions { get; set; } = new();

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


        enum AddressMode
        {
            View,
            Add,
            Edit,
            Delete,
            Select,
            Close
        }

        private AddressMode Mode { get; set; } = AddressMode.View;
        private async Task OnSubmit_UpdateAddress()
        {
            await ProductService.SaveUserAddress(BillingInfo!);
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            if (Mode == AddressMode.Add && BillingInfo!.Sno != 0)
            {
                Addresses!.Add(BillingInfo!);
                Mode = AddressMode.Edit;
            }
            Snackbar.Add("Address updated successfully", Severity.Success);
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
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            if (!Addresses.HasCount(4))
            {
                Mode = AddressMode.Add;
                BillingInfo = new();
            }
            else
            {
                Snackbar.Add("You've reached the maximum number of allowed addresses.", Severity.Error);
                //await JSRuntime.ShowToastAsync("You've reached the maximum number of allowed addresses. No more can be added.", SwalIcon.Error);
            }
        }

        private void OnClick_BtnEditAddress(AddressDTO address)
        {
            Mode = AddressMode.Edit;
            BillingInfo = address;

        }

        private async Task OnClick_BtnDeleteAddress(AddressDTO address)
        {
            Mode = AddressMode.Delete;

            bool? result = await Dialog.ShowMessageBox("Warning", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");

            if (result.GetValueOrDefault())
            {
                var isDeleteSelectedAddress = await ProductService.IsDeletedSelectdAddress(address.Sno);
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
                if (isDeleteSelectedAddress)
                {
                    Addresses!.Remove(address);
                    Snackbar.Add("Address removed successfully!", Severity.Success);

                }
            }
            StateHasChanged();
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
