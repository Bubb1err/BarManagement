using BarManagment.Application.Commoditys.Commands.SaveCommodity;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Commodity> _commodityRepository;

        public CommodityController(
            IMediator mediator,
            IRepository<Commodity> commodityRepository)
        {
            _mediator = mediator;
            _commodityRepository = commodityRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _commodityRepository.GetFirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPut]
        public async Task<IActionResult> SaveCommodity([FromBody]SaveCommodityCommand saveCommodityCommand)
        {
            var commodity = await _mediator.Send(saveCommodityCommand);
            return Ok(commodity);
        }
    }
}
