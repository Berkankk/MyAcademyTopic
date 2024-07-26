using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Topic.DTOLayer.Dtos.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
    public class BlogMapping:Profile
    {
        public BlogMapping()
        {
            CreateMap<ResultBlogDto , Blog>().ReverseMap();
            CreateMap<CreateBlogDto , Blog>().ReverseMap();
            CreateMap<UpdateBlogDto , Blog>().ReverseMap();
        }
    }
}
