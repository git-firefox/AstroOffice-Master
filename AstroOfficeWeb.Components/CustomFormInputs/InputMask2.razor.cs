using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Components.CustomFormInputs
{
    public partial class InputMask2<TValue>
    {
        private ElementReference ER_InputText { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("InputMaskInterop2.fnInitialize", ER_InputText);
                await JSRuntime.InvokeVoidAsync("InputMaskInterop2.fnAddChangeEvent", ER_InputText, DotNetObjectReference.Create(this));
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
