using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AstroShared.Helper;
using AstroOfficeWeb.Client.Pages.Product;

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
        public EventCallback<bool> OnConfirmationChanged { get; set; }

        [Parameter]
        public EventCallback<AddressDTO> OnSelectAddressChanged { get; set; }

        [Parameter]
        public List<AddressDTO>? Addresses { get; set; }

        public AddressDTO? UpdateAddress { get; set; }

        private AddressDTO SelectedAddress { get; set; } = new();


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

        protected async Task OnConfirmationChange(bool isConfirm)
        {
            if (isConfirm)
            {
                await OnSelectAddressChanged.InvokeAsync(SelectedAddress);
            }
        }

        bool AddForm = false;
        private void OnClick_BtnAddAddress(MouseEventArgs e)
        {
            AddForm = true;
        }

        private void OnClick_BtnEditAddress(AddressDTO address)
        {
            StateHasChanged();
        }

        private void OnClick_LabelSelectAddress(AddressDTO address)
        {
            SelectedAddress = address;
        }

        public async Task ShowAsync()
        {
            await JSRuntime.ShowModalAsync(ER_ViewAddressModal);
            StateHasChanged();
        }

        public async Task CloseAsync()
        {
            await JSRuntime.CloseModalAsync(ER_ViewAddressModal);
            StateHasChanged();
        }
    }
}
