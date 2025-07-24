using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Domain;
using System.Data;

namespace Eag.Jwt.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
