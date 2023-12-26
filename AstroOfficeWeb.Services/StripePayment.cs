using Microsoft.AspNetCore.Components;
using Stripe;
using Stripe.Checkout;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Services
{
    public class StripePayment
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigation;

        public StripePayment(HttpClient httpClient, NavigationManager navigation)
        {
            StripeConfiguration.ApiKey = "sk_test_51N4JNqSDthT1ctefV2hXxAss5Ry8I8PRgUmpscORfxdPy2j3d5abB8NbKbctI9FKIXj89KFvRpGJU9h77ytlkOFw00jxWuZIZU";
            _httpClient = httpClient;
            _navigation = navigation;
        }

        public async Task MakePayment(string number, string expMonth, string expYear, string cvc)
        {
            try
            {


                var optionsToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = number,
                        ExpMonth = expMonth,
                        ExpYear = expYear,
                        Cvc = cvc
                    }
                };

                var serviceToken = new TokenService();

                Token stripToken = await serviceToken.CreateAsync(optionsToken);

                var customer = new Stripe.Customer
                {
                    Name = "Test",
                    Address = new Address
                    {
                        Country = "India",
                        City = "Mumbai",
                        Line1 = "Gore Gow",
                        PostalCode = "400606"
                    }
                };

                var options = new ChargeCreateOptions()
                {
                    Amount = 10000,
                    Currency = "INR",
                    Description = "Test",
                    Source = stripToken.Id
                };

                var service = new ChargeService();

                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    //Success 
                }
                else
                {
                    //Faild
                }
            }
            catch (Exception ex)
            {
                _ = ex;
            }

        }

        public async Task<string> CreatePaymentIntent(int amountInCents, string currency = "inr")
        {
            try
            {


                var options = new PaymentIntentCreateOptions
                {
                    Amount = amountInCents,
                    Currency = currency,
                };

                var service = new PaymentIntentService();
                var paymentIntent = await service.CreateAsync(options);

                return paymentIntent.ClientSecret;
                //'pi_3OJg0KSDthT1ctef0HmfMOuA_secret_pAFeHzBBKht6wOzGXvV6hHlS6'
            }
            catch (Exception ex)
            {
                _ = ex;
                return "";
            }
        }

        public Session? CreateCheckoutSession()
        {
            try
            {
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 2000,
                            Currency = "inr",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "T-shirt",
                            },
                        },
                        Quantity = 1,
                    },
                },
                    Mode = "payment",
                    SuccessUrl = _httpClient.BaseAddress + "success",
                    CancelUrl = _httpClient.BaseAddress + "cancel",
                };

                var service = new SessionService();
                Session session = service.Create(options);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            return default;
        }
    }
}
