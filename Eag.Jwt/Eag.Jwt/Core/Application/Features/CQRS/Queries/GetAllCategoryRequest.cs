using Eag.Jwt.Core.Application.Dto;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoryRequest: IRequest<List<CategoryListDto>>
    {

    }
}
