﻿using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ProductGeneralInfo : ComponentBase
    {
        [Parameter]
        public BaseProductDTO Model { get; set; } = null!;

        [Parameter]
        public EventCallback<bool> ValidSubmit { get; set; }
        
        [Parameter]
        public IEnumerable<Option> CategoryItems { get; set; } = Enumerable.Empty<Option>();

        private EditContext GeneralInformationContext { get; set; } = null!;

        private int CharacterCount { get; set; } = 0;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            //    CharacterCount = Convert.ToInt32(ProductModel.Summary?.Length);
            GeneralInformationContext = new EditContext(Model);
        }
        private void UpdateCharacterCount(ChangeEventArgs args)
        {
            string summary = args.Value?.ToString() ?? string.Empty;
            CharacterCount = summary.Length;
        }

        private async Task OnSubmit_EditForm(EditContext context)
        {
            await ValidSubmit.InvokeAsync(context.Validate());
        }
    }
}