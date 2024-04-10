using static System.Runtime.InteropServices.JavaScript.JSType;

namespace STIN_cv_API.Models
{
    public class Payment
    {
        public double Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
    }
}
