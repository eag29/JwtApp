using Eag.Jwt.Core.Application.Dto;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductRequest: IRequest<List<ProductListDto>>
    {
    }
}
