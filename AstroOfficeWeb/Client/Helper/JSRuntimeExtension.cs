using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace AstroOfficeWeb.Client.Helper
{
    public static class JSRuntimeExtension
    {
        public static ValueTask FocusAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeVoidAsync("fnFocusBlazorElement", element);
        }
        public static ValueTask SelectAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeVoidAsync("fnSelectTextBlazorElement", element);
        }

        public static ValueTask ShowModalAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeVoidAsync("fnShowModal", element);
        }
    }
}
