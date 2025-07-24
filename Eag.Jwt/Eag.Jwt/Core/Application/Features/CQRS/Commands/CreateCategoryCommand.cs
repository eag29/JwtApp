using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommand: IRequest
    {
        public string Definition { get; set; }
    }
}
