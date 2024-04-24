using BarManagment.Application.Receipt.Commands.CreateReceipt;
using BarManagment.Application.Receipt.Commands.PayReceipt;
using BarManagment.Application.Receipt.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllReceiptsQuery = new GetAllReceiptsQuery();

            return Ok(await _mediator.Send(getAllReceiptsQuery));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt([FromBody]CreateReceiptCommand createReceiptCommand)
        {
            return Ok(await _mediator.Send(createReceiptCommand));
        }

        [HttpPost("pay")]
        public async Task<IActionResult> PayReceipt([FromQuery] Guid receiptId)
        {
            var payReceiptCommand = new PayReceiptCommand(receiptId);
            return Ok(await _mediator.Send(payReceiptCommand));
        }
    }
}
