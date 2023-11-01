using CashRegister.Models;
using CashRegister.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Controllers
{
    [Route("api/accunt")]
    [ApiController]
    public class AccuntController : ControllerBase
    {

        private readonly IOrderService _orderService;
       
        public AccuntController(IOrderService orderService)
        {
            _orderService = orderService;
        }

       
        
    }
}
