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
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await _repository.DeleteAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
