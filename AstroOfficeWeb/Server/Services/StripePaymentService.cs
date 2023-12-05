using AstroShared.DTOs;
using Stripe;
using Stripe.Checkout;

namespace AstroOfficeWeb.Server.Services
{
    public class StripePaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51N4JNqSDthT1ctefV2hXxAss5Ry8I8PRgUmpscORfxdPy2j3d5abB8NbKbctI9FKIXj89KFvRpGJU9h77ytlkOFw00jxWuZIZU";
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
                SuccessUrl = "https://localhost:5004/order-success",
                CancelUrl = "https://localhost:5004/shopping-cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
