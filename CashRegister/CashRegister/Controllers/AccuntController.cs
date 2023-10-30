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
        private readonly IAccuntService _accuntService;

        public AccuntController(IAccuntService accuntService)
        {
            _accuntService = accuntService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Accunt>>> Get()
        {
            return await _accuntService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Accunt>> Get(string id)
        {
            var shake = await _accuntService.GetAsync(id);

            if (shake is null)
            {
                return NotFound();
            }

            return shake;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accunt newAccunt)
        {
            await _accuntService.CreateAsync(newAccunt);

            return CreatedAtAction(nameof(Get), new { id = newAccunt.Id }, newAccunt);
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Accunt updatedAccunt)
        {
            var shake = await _accuntService.GetAsync(id);

            if (shake is null)
            {
                return NotFound();
            }
            //notice ID is public, fix it!
            updatedAccunt.Id = shake.Id;

            await _accuntService.UpdateAsync(id, updatedAccunt);

            return NoContent();
        }
    }
}
