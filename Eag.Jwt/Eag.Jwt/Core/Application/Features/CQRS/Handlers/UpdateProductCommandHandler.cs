using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedValue = await _repository.GetByIdAsync(request.Id);

            if (updatedValue != null)
            {
                updatedValue.Name = request.Name;
                updatedValue.Stock = request.Stock;
                updatedValue.Price = request.Price;
                updatedValue.Status = request.Status;
                updatedValue.CategoryId = request.CategoryId;
            }
            return Unit.Value;
        }
    }
}
