using AstroOfficeWeb.Shared.ComponentModels;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ProductMetadataInfo : ComponentBase
    {
        [Parameter]
        public List<MetaDataDTO> Items { get; set; } = new List<MetaDataDTO>();

        public MetaDataDTO MetaData { get; set; } = new();

        //public MetaDataDTO? SelectedMetaData { get; set; }
        private MetaDataDTO? BackUpMetaData { get; set; }
        private string? SearchString { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void OnSubmit(EditContext context)
        {
            if (context.Validate())
            {
                Items.Add(new MetaDataDTO
                {
                    MetaValue = MetaData!.MetaValue,
                    MetaKeyword = MetaData.MetaKeyword,
                });
                MetaData = new MetaDataDTO();
            }
        }

        private bool FilterFunc(MetaDataDTO element)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;
            if (element.MetaKeyword!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task OnClick_DeleteMetaData(MetaDataDTO seletedMeta)
        {
            bool? result = await Dialog.ShowMessageBox(title: "Alert", message: "Are you sure you want to delete?", yesText: "Delete", noText: "", cancelText: "Cancel", new DialogOptions() { FullWidth = true });

            if (result.GetValueOrDefault())
            {
                Items.Remove(seletedMeta);
                StateHasChanged();
            }
        }

        private void RowEditPreview(object element)
        {

            if (element.As<MetaDataDTO>() is MetaDataDTO metaData)
            {
                BackUpMetaData = new(metaData);
                Console.WriteLine("RowEditPreview ****************************");
            }
        }

        private void RowEditCancel(object element)
        {
            element = new MetaDataDTO(BackUpMetaData!);
            Console.WriteLine("RowEditCancel ****************************");
        }

        private void RowEditCommit(object element)
        {
            //AddEditionEvent($"RowEditCommit event: Changes to Element {((MetaDataDTO)element).MetaValue} committed");
        }
    }
}
