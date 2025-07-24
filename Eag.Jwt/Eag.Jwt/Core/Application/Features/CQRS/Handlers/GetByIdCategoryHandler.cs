using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetByIdCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetByIdCategoryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}
