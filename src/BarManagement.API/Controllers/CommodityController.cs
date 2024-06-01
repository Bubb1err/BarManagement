using BarManagment.Application.Commoditys.Commands.SaveCommodity;
using BarManagment.Application.Commoditys.Commands.UpdateCommodity;
using BarManagment.Application.Commoditys.Queries.GetAllCommodity;
using BarManagment.Application.Commoditys.Queries.GetCommodityById;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Authorize]
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
        [HttpGet]
        public async Task<IEnumerable<Commodity>> GetAll([FromQuery]Guid userId)
        {
            var getAllCommodityQuery = new GetAllCommodityQuery(userId);
            var commodities = await _mediator.Send(getAllCommodityQuery);
            return commodities;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getCommodityByIdQuery = new GetCommodityByIdQuery(id);
            var commodity = await _mediator.Send(getCommodityByIdQuery);
            return Ok(commodity);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> AddCommodity([FromBody]SaveCommodityCommand saveCommodityCommand)
        {
            var commodity = await _mediator.Send(saveCommodityCommand);
            return Ok(commodity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommodity([FromBody]UpdateCommodityCommand updateCommodityCommand)
        {
            var commodity = await _mediator.Send(updateCommodityCommand);
            return Ok(commodity);
        }
    }
}
