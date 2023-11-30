using System.Text.RegularExpressions;
using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Shared.CustomInputs
{
    public partial class InputNumberMask<TValue> where TValue : IConvertible
    {
        [Parameter]
        public string Placeholder { get; set; } = "_";

        [Parameter]
        public string Mask { get; set; } = null!;

        private ElementReference ER_InputText { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("InputMaskInterop.fnInitialize", ER_InputText, Mask, Placeholder = "_");
                await JSRuntime.InvokeVoidAsync("InputMaskInterop.fnAddChangeEvent", ER_InputText, DotNetObjectReference.Create(this));
            }
        }

        [JSInvokable]
        public void OnInputMaskChange(object value)
        {

            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(string) || targetType == typeof(int) || targetType == typeof(long) || targetType == typeof(short) || targetType == typeof(float) || targetType == typeof(double) || targetType == typeof(decimal))
            {
                string? objString = value.ToString();
                if (!string.IsNullOrEmpty(objString))
                {
                    objString = Regex.Replace(objString, @"\D", "");
                    objString = objString.Substring(0, Math.Min(objString.Length, 10));
                    CurrentValue = (TValue)Convert.ChangeType(objString!, typeof(TValue));
                }
            }
            else
            {
                CurrentValue = default;
            }
            StateHasChanged();
        }
    }
}
