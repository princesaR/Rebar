using Microsoft.AspNetCore.Mvc;
using CashRegister.Services;
using CashRegister.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashRegister.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderControoler : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderControoler(IOrderService orderService)
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
            var shake = await _orderService.GetAsync(id);

            if (shake is null)
            {
                return NotFound();
            }

            return shake;
        }

        // POST api/<OrderControoler>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order newOrder)
        {
            await _orderService.CreateAsync(newOrder);

            return CreatedAtAction(nameof(Get), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Order updatedOrder)
        {
            var shake = await _orderService.GetAsync(id);

            if (shake is null)
            {
                return NotFound();
            }
            //notice ID is public, fix it!
            updatedOrder.Id = shake.Id;

            await _orderService.UpdateAsync(id, updatedOrder);

            return NoContent();
        }

        // DELETE api/<OrderControoler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
