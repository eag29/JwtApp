using Eag.Jwt.Onion.Core.App.Features.CQRS.Commands;
using Eag.Jwt.Onion.Core.App.Interfaces;
using Eag.Jwt.Onion.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Handlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedalue = await _repository.GetByIdAsync(request.Id);
            if (deletedalue != null)
            {
                await _repository.DeleteAsync(deletedalue);
            }
            return Unit.Value;
        }
    }
}
