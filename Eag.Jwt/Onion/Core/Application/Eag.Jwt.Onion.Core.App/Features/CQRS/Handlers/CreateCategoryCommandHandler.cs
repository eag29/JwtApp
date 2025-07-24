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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryDto> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });

            return _mapper.Map<CreateCategoryDto>(data);
        }
    }
}
