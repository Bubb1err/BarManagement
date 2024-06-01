using BarManagment.Application.Coctails.Commands.SaveCoctail;
using BarManagment.Application.Coctails.Commands.UpdateCoctail;
using BarManagment.Application.Coctails.Queries.GetCoctailById;
using BarManagment.Application.Coctails.Queries.GetCoctails;
using BarManagment.Application.Coctails.Queries.SearchCoctails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoctailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoctailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoctails([FromQuery]Guid userId, [FromQuery]string? search)
        {
            var coctails = await _mediator.Send(new GetCoctailsQuery(userId, search));
            return Ok(coctails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoctail(Guid id)
        {
            var getCoctailRequest = new GetCoctailByIdQuery(id);
            var coctail = await _mediator.Send(getCoctailRequest);

            return Ok(coctail);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCoctails(string search)
        {
            var searchCoctailsQuery = new SearchCoctailsQuery(search);
            return Ok(await _mediator.Send(searchCoctailsQuery));
        }

        [HttpPost]
        public async Task<IActionResult> SaveCoctail([FromBody] SaveCoctailCommand saveCoctailCommand)
        {
            var coctail = await _mediator.Send(saveCoctailCommand);
            return Ok(coctail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoctail([FromBody]UpdateCoctailCommand updateCoctailCommand)
        {
            var coctail = await _mediator.Send(updateCoctailCommand);
            return Ok(coctail);
        }
    }
}
