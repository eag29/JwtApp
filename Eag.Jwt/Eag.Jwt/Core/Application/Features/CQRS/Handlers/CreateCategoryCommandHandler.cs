using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });

            return Unit.Value;
        }
    }
}
