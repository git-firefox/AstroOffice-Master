using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.BaseModels
{
    public class BaseMultipartForm<TType> where TType : BaseFormFile
    {
        public List<TType> Files { get; set; } = null!;
    }
}
