using ID3.CQRS.Business.CQRS.Commands.ServicesCommands;
using ID3.CQRS.Business.CQRS.Queries.ServicesQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ID3.CQRS.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
       private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await _mediator.Send(new GetAllServicesQuery());

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteServiceCommand(id));

            return Ok(result);
        }
    }
}
