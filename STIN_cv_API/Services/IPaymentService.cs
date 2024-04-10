using STIN_cv_API.Models;

namespace STIN_cv_API.Services
{
    public interface IPaymentService
    {
        public string ProcessPayment(Payment payment);
    }
}
