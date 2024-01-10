using BarManagment.Application.Commoditys.Commands.SaveCommodity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommodityController(
            IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> SaveCommodity([FromBody]SaveCommodityCommand saveCommodityCommand)
        {
            var commodity = await _mediator.Send(saveCommodityCommand);
            return Ok(commodity);
        }
    }
}
