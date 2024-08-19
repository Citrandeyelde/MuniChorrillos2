using Stripe;
using Stripe.Checkout;
using System.Threading.Tasks;

namespace MuniChorrillos2.Servicios
{
    public class StripeService
    {
        private readonly string _apiKey;

        public StripeService(string apiKey)
        {
            _apiKey = apiKey;
            StripeConfiguration.ApiKey = _apiKey; // Configura la clave secreta aquí
        }

        public async Task<Session> CreateCheckoutSessionAsync(string domain, string amount, string currency)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = long.Parse(amount),
                            Currency = currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Pago de Multa",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = $"{domain}/PagarMulta/Success?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{domain}/PagarMulta/Cancel",
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return session;
        }
    }
}
