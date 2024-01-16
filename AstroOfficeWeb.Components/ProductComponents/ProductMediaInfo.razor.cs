using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Components.ModalComponents;
using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ProductMediaInfo : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> ValidSubmit { get; set; }

        [Parameter]
        public List<MediaFileDTO> Items { get; set; } = null!;

        //private ProductMediaFilesModel ProductMedia { get; set; }

        //private EditContext SaveProductImageInfoContext { get; set; } = null!;

        private void OnClick_SelectFileItems(MediaFileDTO selectedFile)
        {
            var options = new DialogOptions() { CloseButton = true };
            var parameters = new DialogParameters();
            parameters.Add("MediaFile", selectedFile);
            Dialog.Show<ViewFileModal>(selectedFile.MediaName, parameters, options);
        }

        private void OnClick_RemoveImage(MediaFileDTO selectedFile)
        {
            Items.Remove(selectedFile);
        }

        //private async Task OnSubmit_ProductImage(EditContext context)
        //{
        //    await ValidSubmit.InvokeAsync(context.Validate());
        //}

        private async Task FilesChanged(IReadOnlyList<IBrowserFile> files)
        {
            bool fileAdded = false;
            if (files.Count > 10)
            {
                Snackbar.ShowErrorSnackbar($"The maximum number of files accepted is 10, but {files.Count} were supplied.");
                return;
            }

            foreach (IBrowserFile file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.OpenReadStream(file.Size).CopyToAsync(memoryStream);

                    var buffer = memoryStream.ToArray();

                    var base64String = Convert.ToBase64String(buffer);

                    Items.Add(new MediaFileDTO
                    {
                        IsPrimary = false,
                        IsSecondary = false,
                        MediaName = Path.GetFileNameWithoutExtension(file.Name),
                        MediaType = Path.GetExtension(file.Name).ToUpper()[1..],
                        MediaUrl = $"data:{file.ContentType};base64," + base64String,
                        File = new MediaFile
                        {
                            File = file.OpenReadStream(file.Size),
                            Name = Path.GetFileNameWithoutExtension(file.Name),
                            MediaName = file.Name,
                            ContentType = file.ContentType,
                            FileDataUrl = $"data:{file.ContentType};base64," + base64String,
                            MediaType = Path.GetExtension(file.Name).ToUpper()[1..]
                        }
                    });
                    if (!fileAdded) fileAdded = true;
                }
            }
            if (fileAdded) StateHasChanged();
        }

        private void OnCheckedChanged(MediaFileDTO selectedFile, int flag)
        {
            foreach (var file in Items)
            {
                if (file == selectedFile)
                {
                    if (flag == 1)
                        file.IsPrimary = true;
                    else
                        file.IsSecondary = true;
                }
                else
                {
                    if (flag == 1)
                        file.IsPrimary = false;
                    else
                        file.IsSecondary = false;
                }
            }
        }
    }
}
