using Eag.Jwt.Onion.Core.App.Features.CQRS.Commands;
using Eag.Jwt.Onion.Core.App.Features.CQRS.Handlers;
using Eag.Jwt.Onion.Core.App.Features.CQRS.Queires;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eag.Jwt.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
           var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdCategoryQuery(id));
            return result == null ? NotFound() : Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveCategoryCommandRequest(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
