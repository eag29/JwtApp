using Eag.Jwt.Onion.Core.App.Features.CQRS.Commands;
using Eag.Jwt.Onion.Core.App.Features.CQRS.Queires;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eag.Jwt.Api.Controllers
{
    [Authorize(Roles = "Member, Admin")]
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
            await _mediator.Send(new GetAllProductQuery());
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdProductQuery(id));
            return result == null ? NotFound() : Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveProductCommandRequest(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
