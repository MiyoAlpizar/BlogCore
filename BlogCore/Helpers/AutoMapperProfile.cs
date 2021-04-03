using AutoMapper;
using BlogCore.Models.DTOS;
using BlogCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        }
    }
}
