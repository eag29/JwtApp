using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deletedValue = await _repository.GetByFilterAsync(x => x.Id == request.Id);

            if (deletedValue != null)
            {
                await _repository.RemoveAsync(deletedValue);
            }
            return Unit.Value;
        }
    }
}
