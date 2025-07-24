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
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
           var data = await _repository.GetByFilterAsync(x=>x.Id == request.Id);
            return _mapper.Map<ProductListDto>(data);
        }
    }
}
