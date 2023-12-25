using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Utilities
{
    public class Snackbar
    {
        public string Message { get; set; } = null!;
        public SnackbarPosition Position { get; set; } = SnackbarPosition.BottomRight;
        public SnackbarType Type { get; set; } = SnackbarType.Info;

    }
}
