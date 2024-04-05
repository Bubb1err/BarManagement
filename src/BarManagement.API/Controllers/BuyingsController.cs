using BarManagment.Application.Buyings.Commands.SaveBuying;
using BarManagment.Application.Buyings.Queries.GetBuyings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SaveBuyingCommand saveBuyingCommand)
        {
            return Ok(await _mediator.Send(saveBuyingCommand));
        }
    }
}
