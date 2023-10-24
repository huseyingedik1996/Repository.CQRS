using AutoMapper;
using ID3.CQRS.Business.Dtos;
using ID3.CQRS.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.Mapper
{
    public class GeneralMapping : Profile
    {
        
        public GeneralMapping()
        {
            CreateMap<Products, ProductListDto>().ReverseMap();
            CreateMap<Products, CreateProductDto>().ReverseMap();
        }
    }
}
