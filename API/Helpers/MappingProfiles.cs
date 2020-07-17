using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductMaker, o => o.MapFrom(m => m.ProductMaker.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(m => m.ProductType.Name))
                .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
