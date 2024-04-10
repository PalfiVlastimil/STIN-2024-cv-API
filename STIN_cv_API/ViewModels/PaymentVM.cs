namespace STIN_cv_API.ViewModels
{
    public class PaymentVM
    {
        public double Amount { get; set; }
        public string Currency { get; set; } = "";
        public string Date { get; set; } = "";
        public string PaymentType { get; set; } = "";
        public List<string> Items { get; set; } = new List<string>();
    }
}
