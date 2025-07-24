using AutoMapper;
using Eag.Jwt.Onion.Core.App.Dto;
using Eag.Jwt.Onion.Core.App.Features.CQRS.Queires;
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
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
