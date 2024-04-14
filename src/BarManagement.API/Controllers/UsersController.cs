using BarManagment.Application.Users.GetWorkers;
using BarManagment.Application.Users.Login;
using BarManagment.Application.Users.Register;
using BarManagment.Application.Users.Worker;
using BarManagment.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/sign-up")]
        public async Task<IActionResult> Register([FromBody]RegisterCommand registerCommand)
        { 
            return Ok(await _mediator.Send(registerCommand));
        }

        [HttpPost("api/sign-in")]
        public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
        {
            return Ok(await _mediator.Send(loginCommand));
        }

        [HttpPost("api/worker")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateWorker([FromBody]AddWorkerCommand addWorkerCommand)
        {
            await _mediator.Send(addWorkerCommand);
            return Ok();
        }

        [HttpGet("api/workers")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetWorkers([FromQuery]Guid adminId)
        {
            var getUsersQuery = new GetWorkersQuery(adminId);
            return Ok(await _mediator.Send(getUsersQuery));
        }
    }
}
