using AstroShared.DTOs;
using Stripe;
using Stripe.Checkout;

namespace AstroOfficeWeb.Server.Services
{
    public class StripePaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "";
        }

        public Session CreateCheckoutSession(List<CartItemDTO> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.ProductPrice * 100,
                    Currency = "inr",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.ProductName,
                        Images = new List<string> { product!.ProductImageSrc! }
                    }
                },
                Quantity = product.ProductQuantity
            }));

            var options = new SessionCreateOptions
            {
                //CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "US" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7226/order-success",
                CancelUrl = "https://localhost:7226/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
