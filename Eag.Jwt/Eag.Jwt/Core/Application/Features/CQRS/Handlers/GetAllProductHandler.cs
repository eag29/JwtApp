using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductHandler: IRequestHandler<GetAllProductRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}
