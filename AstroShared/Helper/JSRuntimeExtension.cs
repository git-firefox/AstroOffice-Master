
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AstroShared.Helper
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

        public static ValueTask AddSidebarCollapse(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("fnAddSidebarCollapse");
        }
        public static ValueTask AddSidebarClose(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("fnAddSidebarClose");
        }

        public static ValueTask CloseSidebar(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("fnCloseSidebar");
        }

        public static ValueTask CloseModalAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeVoidAsync("fnCloseModal", element);
        }
        public static ValueTask ShowOtpModalAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeVoidAsync("fnShowOtpModal", element);
        }
        public static ValueTask LoadDateTimePickerAsync(this IJSRuntime jsRuntime, ElementReference? element, string format = "MM/DD/YYYY HH:mm:ss")
        {
            return jsRuntime.InvokeVoidAsync("fnLoadDateTimePicker", element, format);
        }

        public static ValueTask<string> GetDateFromDateTimePickerAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeAsync<string>("fnGetDateFromDateTimePicker", element);
        }

        public static ValueTask OpenDocumentInNewTabAsync(this IJSRuntime jsRuntime, string fileName, string base64Data)
        {
            return jsRuntime.InvokeVoidAsync("fnOpenDocumentInNewTab", fileName, base64Data);
        }

        public static ValueTask ApplyInputMaskAsync(this IJSRuntime jsRuntime, ElementReference? element, string mask, string placeHolder = "_")
        {
            return jsRuntime.InvokeVoidAsync("fnApplyInputMask", element, mask, placeHolder);
        }

        public static ValueTask<object> GetInputMaskValueAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeAsync<object>("fnGetInputMaskValue", element);
        }

        public static ValueTask<object> GetOtpValueAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeAsync<object>("fnGetOtpValue", element);
        }

        public static ValueTask ShowToastAsync(this IJSRuntime jsRuntime, string? title, string swalIcon = SwalIcon.Success, string swalPosition = SwalPosition.BottomEnd)
        {
            if (string.IsNullOrEmpty(title))
                title = swalIcon;

            return jsRuntime.InvokeVoidAsync("fnShowToast", title, swalIcon, swalPosition);
        }
    }
}
