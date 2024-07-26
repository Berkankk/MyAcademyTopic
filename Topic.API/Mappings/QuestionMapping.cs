using AutoMapper;
using Topic.DTOLayer.Dtos.QuestionsDto;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping()
        {
            CreateMap<Questions, CreateQuestionDto>().ReverseMap();
            CreateMap<Questions, UpdateQuestionDto>().ReverseMap();
            CreateMap<Questions, ResultQuestionDto>().ReverseMap();
        }

    }
}
