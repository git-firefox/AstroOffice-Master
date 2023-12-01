using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Utilities
{
    public class CalculateOrderSummary
    {
        public decimal GrandTotal { get; private set; }
        public decimal Discount { get; private set; }
        public decimal ShippingCharge { get; private set; }
        public decimal EstimatedTax { get; private set; }
        public decimal Total { get; private set; }

        public decimal DiscountPercentage { get; private set; }
        public decimal ShippingChargePercentage { get; private set; }
        public decimal EstimatedTaxPercentage { get; private set; }

        public CalculateOrderSummary(decimal grandTotal)
        {
            GrandTotal = grandTotal;
            CalculateDiscount();
            CalculateShippingCharge();
            CalculateEstimatedTax();
            CalculateTotal();
        }

        private void CalculateDiscount()
        {
            if (GrandTotal > 5000)
            {
                DiscountPercentage = 10;
                Discount = GrandTotal * (DiscountPercentage / 100); ;
            }
            else if (GrandTotal > 2000)
            {
                DiscountPercentage = 5;
                Discount = GrandTotal * (DiscountPercentage / 100); ;
            }
            else
            {
                Discount = 0;
                DiscountPercentage = 0;
            }
        }

        private void CalculateShippingCharge()
        {
            if (GrandTotal > 5000)
            {
                ShippingCharge = 0;
                ShippingChargePercentage = 0;
            }
            else
            {
                ShippingChargePercentage = 5;
                ShippingCharge = GrandTotal * (ShippingChargePercentage / 100); ;
            }
        }

        private void CalculateEstimatedTax()
        {
            EstimatedTaxPercentage = 1;
            EstimatedTax = GrandTotal * (EstimatedTaxPercentage / 100);
        }

        private void CalculateTotal()
        {
            Total = GrandTotal - Discount + ShippingCharge + EstimatedTax;
        }

    }
}
