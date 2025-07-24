using AutoMapper;
using Eag.Jwt.Core.Application.Dto;
using Eag.Jwt.Core.Domain;
using System.Runtime.InteropServices;

namespace Eag.Jwt.Core.Application.Mappings
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
