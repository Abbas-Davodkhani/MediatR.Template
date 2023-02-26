using MediatR.Template.CommandModels;
using MediatR.Template.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateCustomerCommand createCustomerCommand , CancellationToken cancellationToken)
        {
            CustomerDto dto = await _mediator.Send(createCustomerCommand);
            return CreatedAtAction(nameof(GetCustomerById), new { id = dto.Id });
        }
        [HttpGet]
        public async Task<ActionResult> GetCustomerById(int id , CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
