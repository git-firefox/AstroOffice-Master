using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Shared.CustomInputs
{
    public class Option 
    {
        public string Text { get; set; } = null!;
        public object Value { get; set; } = default!;

        public Option() { }
        public Option(string? text, object value)
        {
            Text = text ?? string.Empty;
            Value = value;
        }
    }

    public partial class InputSelect2<TValue> where TValue : IConvertible
    {
        [Parameter]
        public string? FirstOption { get; set; }


        [Parameter]
        public string Placeholder { get; set; } = "Select an Option";

        [Parameter]
        public IEnumerable<Option> Options { get; set; } = default!;

        private ElementReference ER_InputSelect { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("InputSelect2Interop.fnInitialize", ER_InputSelect);
                await JSRuntime.InvokeVoidAsync("InputSelect2Interop.fnAddChangeEvent", ER_InputSelect, DotNetObjectReference.Create(this));
            }
        }

        [JSInvokable]
        public void OnInputSelect2Change(object value)
        {
            var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
            if (targetType == typeof(string) || targetType == typeof(int) || targetType == typeof(long) || targetType == typeof(short) || targetType == typeof(float) || targetType == typeof(double) || targetType == typeof(decimal))
            {
                CurrentValue = (TValue)Convert.ChangeType(value.ToString()!, typeof(TValue));
            }
            else
            {
                CurrentValue = default;
            }
            StateHasChanged();
        }
    }
}
