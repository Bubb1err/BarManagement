using BarManagment.Application.Drinks.Commands.SaveDrink;
using BarManagment.Application.Drinks.Commands.UpdateDrink;
using BarManagment.Application.Drinks.Queries.GetDrinkById;
using BarManagment.Application.Drinks.Queries.GetDrinks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DrinksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrinkById(Guid id)
        {
            var drink = await _mediator.Send(new GetDrinkByIdQuery(id));
            return Ok(drink);
        }
        [HttpGet]
        public async Task<IActionResult> GetDrinks()
        {
            var drinks = await _mediator.Send(new GetDrinksQuery());
            return Ok(drinks);
        }
        [HttpPost]
        public async Task<IActionResult> SaveDrink([FromBody]SaveDrinkCommand saveDrinkCommand)
        {
            var drink = await _mediator.Send(saveDrinkCommand);
            return Ok(drink);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDrink([FromBody]UpdateDrinkCommand updateDrinkCommand)
        {
            var drink = await _mediator.Send(updateDrinkCommand);
            return Ok(drink);
        }
    }
}
