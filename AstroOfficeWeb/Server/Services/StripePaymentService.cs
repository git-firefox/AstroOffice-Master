using AstroOfficeWeb.Server.Services.IServices;
using AstroShared.DTOs;
using AstroShared.Utilities;
using Stripe;
using Stripe.Checkout;

namespace AstroOfficeWeb.Server.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51N4JNqSDthT1ctefV2hXxAss5Ry8I8PRgUmpscORfxdPy2j3d5abB8NbKbctI9FKIXj89KFvRpGJU9h77ytlkOFw00jxWuZIZU";
        }

        public Session CreateCheckoutSession(List<CartItemDTO> cartItems)
        {
            try
            {
                var totalPlusExpress = cartItems.Sum(ci => ci.ProductQuantity * ci.ProductPrice);
                var orderSummary = new CalculateOrderSummary(totalPlusExpress);

                var lineItems = new List<SessionLineItemOptions>();
                cartItems!.ForEach(product => lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = product.ProductPrice * 100,
                        Currency = "inr",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.ProductName,
                            //Images = new List<string> { product!.ProductImageSrc! }
                        }
                    },
                    Quantity = product.ProductQuantity,
                }));


                var options = new SessionCreateOptions
                {
                    //CustomerEmail = _authService.GetUserEmail(),
                    ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "IN" }
                    },
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = lineItems,
                    
                    Mode = "payment",
                    SuccessUrl = "https://localhost:5004/order-success?session_id={CHECKOUT_SESSION_ID}",
                    CancelUrl = "https://localhost:5004/shopping-cart"
                };

                var service = new SessionService();
                Session session = service.Create(options);
                return session;
            }
            catch (Exception ex)
            {
                _ = ex;
                throw new Exception("Failed");
            }

        }
    }
}
