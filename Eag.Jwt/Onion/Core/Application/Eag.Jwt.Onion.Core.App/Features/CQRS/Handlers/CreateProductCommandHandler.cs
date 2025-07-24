using AutoMapper;
using Eag.Jwt.Onion.Core.App.Dto;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreatedProductDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(new Product
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                Status = request.Status,
                CategoryId = request.CategoryId,
            });

            return _mapper.Map<CreatedProductDto>(data);
        }
    }
}
