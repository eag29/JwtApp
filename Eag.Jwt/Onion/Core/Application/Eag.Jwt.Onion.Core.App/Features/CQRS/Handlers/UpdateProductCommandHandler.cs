using Eag.Jwt.Onion.Core.App.Features.CQRS.Commands;
using Eag.Jwt.Onion.Core.App.Interfaces;
using Eag.Jwt.Onion.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Name = request.Name;
                updatedEntity.Stock = request.Stock;
                updatedEntity.Price = request.Price;
                updatedEntity.Status = request.Status;
                updatedEntity.CategoryId = request.CategoryId;
                await _repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
