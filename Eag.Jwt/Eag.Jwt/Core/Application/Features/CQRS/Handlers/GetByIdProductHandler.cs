using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetByIdProductHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var id = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<ProductListDto>(id);
        }
    }
}
