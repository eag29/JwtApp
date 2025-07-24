using AutoMapper;
using Eag.Jwt.Onion.Core.App.Dto;
using Eag.Jwt.Onion.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, CreatedProductDto>().ReverseMap();
        }
    }
}
