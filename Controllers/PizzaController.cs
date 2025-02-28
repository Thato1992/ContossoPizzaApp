using Microsoft.AspNetCore.Mvc;
using ContossoPizzaApp.Models;
using ContossoPizzaApp.Services;

namespace ContossoPizzaApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        // Inject the PizzaService
        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: api/pizza
        [HttpGet]
        public async Task<IActionResult> GetPizzas()
        {
            var pizzas = await _pizzaService.GetPizzasAsync();
            return Ok(pizzas);
        }

        // GET: api/pizza/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizza(int id)
        {
            var pizza = await _pizzaService.GetPizzaByIdAsync(id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        // POST: api/pizza
        [HttpPost]
        public async Task<IActionResult> CreatePizza([FromBody] Pizza pizza)
        {
            if (pizza == null)
                return BadRequest("Pizza data is required.");

            var createdPizza = await _pizzaService.AddPizzaAsync(pizza);
            return CreatedAtAction(nameof(GetPizza), new { id = createdPizza.Id }, createdPizza);
        }

        // PUT: api/pizza/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, [FromBody] Pizza updatedPizza)
        {
            if (updatedPizza == null)
                return BadRequest("Updated pizza data is required.");

            var pizza = await _pizzaService.UpdatePizzaAsync(id, updatedPizza);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        // DELETE: api/pizza/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var result = await _pizzaService.DeletePizzaAsync(id);
            if (!result)
                return NotFound();

            return NoContent(); // 204 No Content, indicating the resource was deleted
        }
    }
}
