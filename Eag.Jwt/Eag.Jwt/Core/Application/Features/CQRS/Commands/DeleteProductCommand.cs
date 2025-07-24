using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommand: IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
