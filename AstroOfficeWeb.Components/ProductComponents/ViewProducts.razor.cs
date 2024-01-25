﻿using AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ViewProducts
    {
        [Parameter]
        public EventCallback<bool> EventCallback { get; set; }

        [Parameter]
        public string? CategorySno { get; set; } = null;
        [Parameter]
        public string? CategoryName { get; set; } = null;

        [Parameter]
        public int CurrentPage { get; set; } = 1;

        [Parameter]
        public bool IsDataUrl { get; set; } = false;

        public bool IsDrawerOpen { get; set; }
        private string sortByPrice = "";
        private string pageSize = "";

        public List<ViewProductDTO>? Products { get; set; }
        private List<ViewProductDTO> FilteredProducts = new List<ViewProductDTO>();
        private List<ViewProductDTO> ListedProducts = new List<ViewProductDTO>();
        private List<PCategoryDTO>? CategoryDTOs { get; set; }

        private int PageSize { get; set; } = 40;
        private int TotalPages => (int)Math.Ceiling((double)FilteredProducts.Count / PageSize);

        private bool IsFirstPage { get; set; }
        private bool IsLastPage { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CategoryDTOs = await ProductService.GetShopCategories();
            Products = await ProductService.GetProducts(isDataUrl: IsDataUrl);
            if (Products is not null)
            {
                await ApplyFilter();

            }
        }

        private void OnClick_BtnClose(MouseEventArgs e)
        {
            IsDrawerOpen = !IsDrawerOpen;
        }

        private async Task PageChanged(int i)
        {
            CurrentPage = i;
            UpdateVisibleItems();
            //.NavigateTo(i - 1);
        }

        private async Task OnClick_CategoryList(BaseCategoryDTO category)
        {
            Products = await ProductService.GetProducts(category.Sno, isDataUrl: IsDataUrl);
            await ApplyFilter();
            NavigationManager.NavigateTo($"/products/{category.Sno}/{category!.Title!.Replace(" ", "-").ToLower()}");
        }

        private async Task OnClick_BtnAddToCart(ViewProductDTO product)
        {
            var tempQuantity = product!.ProductQuantity + 1;
            if (tempQuantity < 1 || tempQuantity > 5)
            {
                await JSRuntime.ShowToastAsync($"Unable to add more products to your cart. Limit exceeded.", SwalIcon.Error);
                return;
            }

            bool isAddedToCart = await ProductService.IsAddToCart(product.Sno);
            if (isAddedToCart)
            {
                product.ProductQuantity += 1;
                await JSRuntime.ShowToastAsync($"\"{product.Name}\" added to your cart.", SwalIcon.Success);
            }
        }

        private async Task OnClick_ALinkView(ViewProductDTO product)
        {
            //await LocalStorage.SetItemAsync<ViewProductDTO>(ApplicationConst.Local_SelectedProduct, product);
            NavigationManager.NavigateTo($"/product/{product.Sno}/{product.Name.Replace("'", "-").ToLower()}");
        }
        private async Task OnClick_BtnClear()
        {

            // await JSRuntime.InvokeVoidAsync("location.reload");
            sortByPrice = "";
            pageSize = "";
            searchString = "";
            Products = await ProductService.GetProducts(isDataUrl: IsDataUrl);
            await ApplyFilter();
            IsDrawerOpen = false;
            await Form.ResetAsync();
        }


        private MudForm Form { get; set; } = null!;
        private async Task ApplyFilter()
        {
            FilteredProducts = Products!.ToList();
            //  searchString = await JSRuntime.InvokeAsync<string>("getSearchboxValue");
            // var searchStrings = searchString;
            filter = await JSRuntime.InvokeAsync<string>("getDropdownValue");
            size = await JSRuntime.InvokeAsync<string>("getPageSizeValue");
            PageSize = string.IsNullOrEmpty(size) ? 24 : Convert.ToInt32(size);

            if (!string.IsNullOrEmpty(searchString))
            {
                FilteredProducts = Products!.Where(item => item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filter == "Low-Max")
            {
                FilteredProducts = FilteredProducts.OrderBy(x => x.Price).ToList();
            }
            else if (filter == "Max-Low")
            {
                FilteredProducts = FilteredProducts.OrderByDescending(x => x.Price).ToList();
            }

            CurrentPage = 1;
            UpdateVisibleItems();
        }
        private string searchString = "";
        private string size = "";
        private string filter = "";

        private void FilterFunc(string value)
        {
            FilteredProducts = Products!.ToList();
            searchString = value.ToStringX(); // Update the searchString
            PageSize = string.IsNullOrEmpty(size) ? 24 : Convert.ToInt32(size);
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                FilteredProducts = Products!.Where(item => item.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filter == "Low-Max")
            {
                FilteredProducts = FilteredProducts.OrderBy(x => x.Price).ToList();
            }
            else if (filter == "Max-Low")
            {
                FilteredProducts = FilteredProducts.OrderByDescending(x => x.Price).ToList();
            }

            UpdateVisibleItems();
            //else
            //{
            //    FilteredProducts = FilteredProducts ?? Enumerable.Empty<PersonKundaliTableTRModel>(); ;
            //}
        }

        public void OnSwipe(SwipeEventArgs direction)
        {
            if (direction.SwipeDirection == SwipeDirection.LeftToRight)
            {
                IsDrawerOpen = false;
                StateHasChanged();
            }
        }

        private void UpdateVisibleItems()
        {
            int startIndex = (CurrentPage - 1) * PageSize;
            ListedProducts = FilteredProducts.Skip(startIndex).Take(PageSize).ToList();
            IsFirstPage = CurrentPage == 1;
            IsLastPage = CurrentPage == TotalPages;
        }

        private void NextPage()
        {
            CurrentPage++;
            if (!IsLastPage)
            {
                UpdateVisibleItems();
            }
        }

        private void PreviousPage()
        {
            if (!IsFirstPage)
            {
                CurrentPage--;
                UpdateVisibleItems();
            }
        }

        bool IsFilterOpened = false;

        public void OnClick_BtnFilter(MouseEventArgs e)
        {
            //if (!IsFilterOpened)
            //{
            //    //await JSRuntime.InvokeVoidAsync("eval", "document.getElementsByClassName('categories')[0].style.left = '0px'");
            //    //IsFilterOpened = true;
            //}
            //else
            //{
            //    //await JSRuntime.InvokeVoidAsync("eval", "document.getElementsByClassName('categories')[0].style.left = '-500px'");
            //   // IsFilterOpened = false;
            //}

            IsDrawerOpen = true;

            //await EventCallback.InvokeAsync(true);
        }






    }
}
