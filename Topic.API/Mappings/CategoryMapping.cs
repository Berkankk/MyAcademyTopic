using AutoMapper;
using Topic.DTOLayer.Dtos.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto,Category>().ReverseMap(); //tersinede eşitle
            CreateMap<CreateCategoryDto, Category>().ReverseMap(); //tersinede eşitle
            CreateMap<UpdateCategoryDto,Category>().ReverseMap(); //tersinede eşitle
        
        }
    }
}
