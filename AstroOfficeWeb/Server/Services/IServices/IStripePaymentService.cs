using AstroShared.DTOs;
using Stripe.Checkout;

namespace AstroOfficeWeb.Server.Services.IServices
{
    public interface IStripePaymentService
    {
        Session CreateCheckoutSession(List<CartItemDTO> cartItems);
    }
}
