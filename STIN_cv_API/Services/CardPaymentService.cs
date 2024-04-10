using STIN_cv_API.Models;

namespace STIN_cv_API.Services
{
    public class CardPaymentService : IPaymentService
    {
        public string ProcessPayment(Payment payment)
        {
            return payment.Amount + "/" + payment.Currency;
        }

    }
}
