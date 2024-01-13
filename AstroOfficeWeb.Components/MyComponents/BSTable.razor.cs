using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Components.MyComponents
{
    public partial class BSTable : ComponentBase
    //public partial class BSTable<TItem> : ComponentBase
    {
        //[Parameter]
        //public RenderFragment THeadTemplate { get; set; } = null!;

        [Parameter]
        public IEnumerable<string> THeadItems { get; set; } = null!;

        //[Parameter]
        //public RenderFragment LoaderI { get; set; } = null!;

        //[Parameter]
        //public RenderFragment<TItem> TBodyTemplate { get; set; } = null!;

    }
}
