using Newtonsoft.Json;
using STIN_cv_API.Models;
using STIN_cv_API.ViewModels;
using System.Text.Json;
using System.Xml.Serialization;
namespace STIN_cv_API.Services
{
    public static class PaymentTransformations
    {
        public static string TransformXMLFromPayment(PaymentVM payment)
        {
            return JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(payment), "Payment").OuterXml;
        }

        public static Payment TransformPaymentFromString(string payload)
        {
            try
            {
                return JsonConvert.DeserializeObject<Payment>(payload);
            }
            catch (JsonSerializationException e)
            {
                throw;
            }
        }
        public static PaymentVM TransformPaymentVMFromPayment(Payment payment)
        {
            return new PaymentVM
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Date = payment.Date.ToString("yyyy-MM-dd"),
                PaymentType = payment.PaymentType,
                Items = payment.Items
            };
        }

    }
}
