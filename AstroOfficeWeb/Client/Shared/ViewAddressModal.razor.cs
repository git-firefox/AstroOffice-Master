using AstroShared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AstroShared.Helper;

namespace AstroOfficeWeb.Client.Shared
{
    public partial class ViewAddressModal
    {
        protected bool IsShow { get; set; } = true;
        protected ElementReference ER_ViewAddressModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Address";

        [Parameter]
        public AddressDTO? DefaultAddress { get; set; }

        [Parameter]
        public EventCallback<bool> OnConfirmationChanged { get; set; }

        [Parameter]
        public List<AddressDTO>? Addresses { get; set; }

        public AddressDTO? AddressDTO { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task OnConfirmationChange(bool value)
        {
            await OnConfirmationChanged.InvokeAsync(value);
        }

        private void OnClick_BtnAddAddress(MouseEventArgs e)
        {
            StateHasChanged();
        }  
        
        private void OnClick_BtnEditAddress(AddressDTO address)
        {
            StateHasChanged();
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
