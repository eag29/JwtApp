using Eag.Jwt.Core.Application.Dto;
using MediatR;

namespace Eag.Jwt.Core.Application.Features.CQRS.Queries
{
    public class GetByIdProductRequest: IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetByIdProductRequest(int id)
        {
            Id = id;
        }
    }
}
