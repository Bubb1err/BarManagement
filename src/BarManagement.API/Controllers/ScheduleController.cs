using BarManagment.Application.Schedule.AddSchedule;
using BarManagment.Application.Schedule.GetScheduleByUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize (Roles = "Manager")]
        public async Task<IActionResult> CreateSchedule([FromBody]AddScheduleCommand scheduleCommand)
        {
            return Ok(await _mediator.Send(scheduleCommand));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSchedule([FromQuery]Guid barmenId)
        {
            var getScheduleQuery = new GetScheduleByUserQuery(barmenId);
            return Ok(await _mediator.Send(getScheduleQuery));
        }
    }
}
