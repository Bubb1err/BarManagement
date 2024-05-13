using BarManagment.Application.Buyings.Commands.SaveBuying;
using BarManagment.Application.Buyings.Queries.GetBuyings;
using BarManagment.Application.Buyings.Queries.GetSpendings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuyingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetBuyingsQuery()));
        }

        [HttpGet("spendings")]
        public async Task<IActionResult> GetSpendings()
        {
            return Ok(await _mediator.Send(new GetSpendingsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SaveBuyingCommand saveBuyingCommand)
        {
            return Ok(await _mediator.Send(saveBuyingCommand));
        }
    }
}
