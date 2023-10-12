﻿using Microsoft.AspNetCore.Components;
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
        public static ValueTask LoadDateTimePickerAsync(this IJSRuntime jsRuntime, ElementReference? element, string format = "MM/DD/YYYY HH:mm:ss")
        {
            return jsRuntime.InvokeVoidAsync("fnLoadDateTimePicker", element, format);
        }
        
        public static ValueTask<string> GetDateFromDateTimePickerAsync(this IJSRuntime jsRuntime, ElementReference? element)
        {
            return jsRuntime.InvokeAsync<string>("fnGetDateFromDateTimePicker", element);
        }
        //public static ValueTask<DateTime> GetDateFromDateTimePickerAsync(this IJSRuntime jsRuntime, ElementReference? element)
        //{
        //    return jsRuntime.InvokeAsync<DateTime>("fnGetDateFromDateTimePicker", element);
        //}
    }
}
