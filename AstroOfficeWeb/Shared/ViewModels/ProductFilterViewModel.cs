﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.ViewModels
{
    public class ProductFilterViewModel
    {
        public ProductSorting Sorting { get; set; } = ProductSorting.Default;
        public string? Search { get; set; }
        public int Page { get; set; } = 25;
    }
}