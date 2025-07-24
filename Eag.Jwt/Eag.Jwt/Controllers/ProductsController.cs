using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Eag.Jwt.Controllers
{
    [Authorize(Roles = "Admin, Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAllProductRequest());
            return Created("", result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdProductRequest(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
