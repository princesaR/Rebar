using CashRegister.Services;
using CashRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Controllers
{
    [Route("api/shake")]
    public class ShakeController : Controller
    {

        private readonly IShakeService _shakeService;

        public ShakeController(IShakeService shakeService)
        {
            _shakeService = shakeService;
        }
       

        [HttpGet]
        public async Task<ActionResult<List<Shake>>> Get()
        {
             return await _shakeService.GetAsync();
        }
        


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Shake>> Get(string id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shake = await _shakeService.GetAsync(id);

            return shake;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shake newShake)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _shakeService.CreateAsync(newShake);

            return CreatedAtAction(nameof(Get), new { id = newShake.Id }, newShake);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id,[FromBody] Shake updatedShake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _shakeService.UpdateAsync(id, updatedShake);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            await _shakeService.RemoveAsync(id);

            return NoContent();
        }

    }
}
