using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Commands
{
    public class CreateProductCommand: IRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
