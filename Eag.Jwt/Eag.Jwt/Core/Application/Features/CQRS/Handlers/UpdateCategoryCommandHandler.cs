using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedValue = await _repository.GetByIdAsync(request.Id);

            if (updatedValue != null)
            {
                updatedValue.Definition = request.Definition;
                await _repository.UpdateAsync(updatedValue);
            }
            return Unit.Value;
        }
    }
}
