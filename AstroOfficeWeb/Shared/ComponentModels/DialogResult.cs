using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.ComponentModels
{
    public class MyDialogResult<TResult>
    {
        public bool? Result { get; set; }
        public TResult? Data { get; set; }
    }
}
