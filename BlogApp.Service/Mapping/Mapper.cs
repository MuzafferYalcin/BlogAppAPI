using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Yorum, YorumDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<YazarForRegister,Yazar>();
            CreateMap<Yazar,YazarDto>().ReverseMap();
            CreateMap<AddBlogDto, Blog>();
            CreateMap<Yazar, LoginResult>();
            CreateMap<Blog, AddBlogDto>().ReverseMap();
        }
    }
}
