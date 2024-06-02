// Set your secret key. Remember to switch to your live secret key in production!
// You can find your API keys in the Stripe Dashboard.
using Stripe.Checkout;
using Stripe;

StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc"; // Replace with your actual test secret key

var options = new SessionCreateOptions
{
    PaymentMethodTypes = new List<string>
            {
                "card",
            },
    LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "dkk",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Helt sikkert ikke et scam",
                        },
                        UnitAmount = 420, 
                    },
                    Quantity = 69,
                },
            },
    Mode = "payment",
    SuccessUrl = "https://http.cat/status/200", 
    CancelUrl = "https://http.cat/status/400", 
};

var service = new SessionService();
Session session = service.Create(options);

Console.WriteLine($"Checkout session created: {session.Id}");
Console.WriteLine($"Checkout URL: {session.Url}");