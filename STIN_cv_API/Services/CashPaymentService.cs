using STIN_cv_API.Models;
using STIN_cv_API.ViewModels;

namespace STIN_cv_API.Services
{
    public class CashPaymentService : IPaymentService
    {
        public string ProcessPayment(Payment payment)
        {
            var paymentVM = PaymentTransformations.TransformPaymentVMFromPayment(payment);
            string result = PaymentTransformations.TransformXMLFromPayment(paymentVM);
            return result;
        }
    }
}
