using Eag.Jwt.Core.Application.Dto;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Queries
{
    public class GetByIdCategoryRequest: IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetByIdCategoryRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
