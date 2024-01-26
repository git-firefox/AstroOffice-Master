using AstroOfficeWeb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Components.ProductComponents
{
    public partial class ManageOrders
    {
        [Parameter]
        public string GridClass { get; set; } = string.Empty;
        private IEnumerable<OrderDTO>? OrderDTOs { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            OrderDTOs = await ProductService.GetOrders();
        }

        private void OnClick_BtnViewOrder(OrderDTO order)
        {
            NavigationManager.NavigateTo($"/view-order/{order.OrderId}");
        }
        //void OpenFilter()
        //{
        //    _filterOpen = true;
        //}

        //private void SelectedChanged(bool value, OrderDTO item)
        //{
        //    if (value)
        //        _selectedItems.Add(item);
        //    else
        //        _selectedItems.Remove(item);

        //    if (_selectedItems.Count == OrderDTOs.Count())
        //        _selectAll = true;
        //    else
        //        _selectAll = false;
        //}

        //private async Task ClearFilterAsync(FilterContext<OrderDTO> context)
        //{
        //    _selectedItems = OrderDTOs.ToHashSet();
        //    _filterItems = OrderDTOs.ToHashSet();
        //    _icon = Icons.Material.Outlined.FilterAlt;
        //    await context.Actions.ClearFilterAsync(_filterDefinition);
        //    _filterOpen = false;
        //}

        //private async Task ApplyFilterAsync(FilterContext<OrderDTO> context)
        //{
        //    _filterItems = _selectedItems.ToHashSet();
        //    _icon = _filterItems.Count == OrderDTOs.Count() ? Icons.Material.Outlined.FilterAlt : Icons.Material.Filled.FilterAlt;
        //    await context.Actions.ApplyFilterAsync(_filterDefinition);
        //    _filterOpen = false;
        //}

        //private void SelectAll(bool value)
        //{
        //    _selectAll = value;

        //    if (value)
        //    {
        //        _selectedItems = OrderDTOs.ToHashSet();
        //    }
        //    else
        //    {
        //        _selectedItems.Clear();
        //    }
        //}
    }

}
