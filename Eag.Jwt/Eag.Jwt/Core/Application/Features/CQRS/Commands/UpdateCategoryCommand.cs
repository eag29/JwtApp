using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand: IRequest
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
