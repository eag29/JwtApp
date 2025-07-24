using Eag.Jwt.Core.Application.Features.CQRS.Commands;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deletedvalue = await _repository.GetByIdAsync(request.Id);

            if (deletedvalue != null)
            {
                await _repository.RemoveAsync(deletedvalue);
            }
            return Unit.Value;
        }
    }
}
