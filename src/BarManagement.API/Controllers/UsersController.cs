using BarManagment.Application.Users.Login;
using BarManagment.Application.Users.Register;
using MediatR;
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
    }
}
