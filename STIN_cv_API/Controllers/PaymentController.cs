using Microsoft.AspNetCore.Mvc;
using STIN_cv_API.Services;

namespace STIN_cv_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly PaymentProcessingHandler _paymentProcessingHandler;

        public PaymentController()
        {
            _paymentProcessingHandler = new PaymentProcessingHandler();
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }

        [HttpGet("time")]
        public IActionResult Time()
        {
            return Ok(DateTime.Now.ToString());
        }

        [HttpPost("pay/string")]
        public IActionResult ProcessPayment([FromBody] string payload)
        {
            try
            {
                var payment = PaymentTransformations.TransformPaymentFromString(payload);
                return Ok(_paymentProcessingHandler.ProcessPayment(payment));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
