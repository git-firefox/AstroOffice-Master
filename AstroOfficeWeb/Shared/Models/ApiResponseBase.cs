﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class ApiResponseBase
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int ErrorNo { get; set; }
    }
}
