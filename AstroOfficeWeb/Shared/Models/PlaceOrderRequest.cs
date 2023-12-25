using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;


namespace AstroOfficeWeb.Shared.Models
{
    public class PlaceOrderRequest
    {
        public DateTime OrderDate { get; set; }//
        public PaymentMethod PaymentMethod { get; set; }
        public long ShippingAddressSno { get; set; }//
        public long BillingAddressSno { get; set; }//
        public bool ShipToDifferentAddress { get; set; }//
        public string? OrderNotes { get; set; }//
        public ShippingMethod ShippingMethod { get; set; }//
    }
}
