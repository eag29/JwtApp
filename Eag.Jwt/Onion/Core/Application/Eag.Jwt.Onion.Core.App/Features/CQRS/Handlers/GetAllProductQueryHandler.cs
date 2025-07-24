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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}
