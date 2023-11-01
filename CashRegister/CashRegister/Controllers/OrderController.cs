using Microsoft.AspNetCore.Mvc;
using CashRegister.Services;
using CashRegister.Models;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using CashRegister.LogicLayer;
using CashRegister.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashRegister.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderLogic _orderLogic;
        private readonly IOrderService _orderService;
        public OrderController(IOrderLogic orderLogic, IOrderService orderService)
        {
            _orderLogic = orderLogic;
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return await _orderService.GetAsync();
        }

        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var order =  await _orderLogic.GetAsync(id);
                return order;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> Post(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            { 
                var order = await _orderLogic.Post(orderDto);
                return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                   return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


      

       

        
    }
}
