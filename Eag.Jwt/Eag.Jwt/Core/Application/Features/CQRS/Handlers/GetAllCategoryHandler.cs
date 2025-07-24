using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Application.Features.CQRS.Queries;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Domain;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var data =  await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
