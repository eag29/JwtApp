using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Product
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Status = request.Status,
            });

            return Unit.Value;
        }
    }
}
