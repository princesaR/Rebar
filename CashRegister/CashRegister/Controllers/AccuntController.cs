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
            try
            {
                return await _accuntService.GetAsync();
            }
            catch (Exception ex) { }
            {
                throw new Exception("");
            }
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Accunt>> Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
               var shake = await _accuntService.GetAsync(id);

                return shake;
            }
            catch (Exception ex)
            {
                throw new Exception("");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accunt newAccunt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _accuntService.CreateAsync(newAccunt);

                return CreatedAtAction(nameof(Get), new { id = newAccunt.Id }, newAccunt);
            }
            catch( Exception ex)
            {
                throw new Exception();
            }
           
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Accunt updatedAccunt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _accuntService.UpdateAsync(id, updatedAccunt);
                return CreatedAtAction(nameof(Get), new { id = updatedAccunt.Id }, updatedAccunt);
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
