using System;
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
        [Parameter, EditorRequired]
        public BaseProductDTO Model { get; set; } = null!;

        [Parameter]
        public EventCallback<bool> ValidSubmit { get; set; }
        
        [Parameter, EditorRequired]
        public IEnumerable<Option> CategoryItems { get; set; } = Enumerable.Empty<Option>();

        public EditContext GeneralInformationContext { get; set; } = null!;

        private int CharacterCount { get; set; } = 0;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            CharacterCount = Convert.ToInt32(Model.Summary?.Length);
            GeneralInformationContext = new EditContext(Model);
        }
        private void UpdateCharacterCount(ChangeEventArgs args)
        {
            string summary = args.Value?.ToString() ?? string.Empty;
            CharacterCount = summary.Length;
        }

    }
}
