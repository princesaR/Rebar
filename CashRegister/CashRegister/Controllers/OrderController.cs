using Microsoft.AspNetCore.Mvc;
using CashRegister.Services;
using CashRegister.Models;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashRegister.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return await _orderService.GetAsync();
        }


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var shake = await _orderService.GetAsync(id);

            return shake;
        }

        // POST api/<OrderControoler>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _orderService.CreateAsync(newOrder);

                return CreatedAtAction(nameof(Get), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                   return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Order updatedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _orderService.UpdateAsync(id, updatedOrder);

            return NoContent();
        }

        
    }
}
