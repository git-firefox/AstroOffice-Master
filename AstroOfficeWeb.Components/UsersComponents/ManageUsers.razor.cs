﻿using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Shared.Utilities;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace AstroOfficeWeb.Components.UsersComponents
{
    public partial class ManageUsers : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> UsersLoaded { get; set; }

        private bool IsDrawerOpen { get; set; }
        private string DrawerTitle { get; set; } = null!;
        private bool IsSaveUserFormValid { get; set; }
        private ActionMode SaveUserFormMode { get; set; }
        private SaveUserModel SaveUserModel { get; set; } = new();
        private IList<UserListItemModel>? Users { get; set; }
        private MudForm Form { get; set; } = null!;


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Users = await Account.GetUsers();
            await UsersLoaded.InvokeAsync(true);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        private void OnClick_BtnClose(MouseEventArgs e)
        {
            IsDrawerOpen = !IsDrawerOpen;
        }

        public async Task OnClick_BtnAction(ActionMode mode = ActionMode.Add, UserListItemModel? selectedUser = null)
        {
            await Form.ResetAsync();
            switch (mode)
            {
                case ActionMode.Add:
                    {
                        DrawerTitle = "Add User";
                        break;
                    }
                case ActionMode.View:
                    {
                        DrawerTitle = "View User";
                        break;
                    }
                case ActionMode.Edit:
                    {
                        DrawerTitle = "Edit User";
                        break;
                    }
                case ActionMode.Delete:
                    {
                        bool? result = await Dialog.ShowMessageBox("Warning", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
                        if (result.GetValueOrDefault())
                        {
                            Users!.Remove(selectedUser!);
                        }
                        return;
                    }
            }

            if (selectedUser != null)
            {
                SaveUserModel = new(selectedUser);
            }
            else
            {
                SaveUserModel = new();
            }
            SaveUserFormMode = mode;
            IsDrawerOpen = true;
            StateHasChanged();
        }

        private async Task OnClick_BtnSave(MouseEventArgs e)
        {
            await Form.Validate();
            if (Form.IsValid)
            {
                if (await Account.IsUsedSavedAsync(SaveUserModel, SaveUserModel.Password))
                {
                    switch (SaveUserFormMode)
                    {
                        case ActionMode.Add:
                            {
                                Users!.Add(new(SaveUserModel));
                                break;
                            }
                        case ActionMode.Edit:
                            {
                                var existedUser = Users!.First(a => a.Sno == SaveUserModel.Sno);
                                var index = Users!.IndexOf(existedUser);
                                Users[index] = new(SaveUserModel);
                                break;
                            }
                    }
                    IsDrawerOpen = !IsDrawerOpen;
                    //StateHasChanged();
                }
            }
        }

        private IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            //if (pw.Length < 8)
            //    yield return "Password must be at least of length 8";
            //if (!Regex.IsMatch(pw, @"[A-Z]"))
            //    yield return "Password must contain at least one capital letter";
            //if (!Regex.IsMatch(pw, @"[a-z]"))
            //    yield return "Password must contain at least one lowercase letter";
            //if (!Regex.IsMatch(pw, @"[0-9]"))
            //    yield return "Password must contain at least one digit";
        }

        private string? PasswordMatch(string arg)
        {
            if (SaveUserModel.Password != arg)
                return "Passwords don't match";
            return null;
        }

    }
}
