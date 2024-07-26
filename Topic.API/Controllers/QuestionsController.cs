using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.QuestionsDto;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllQuestionss()
        {
            var soru = _questionService.TGetList();
            var value = _mapper.Map<List<ResultQuestionDto>>(soru);  //soru ile gelen değeri mapledik
            return Ok(value);
        }

        [HttpGet("{id}")] //id ye göre getirme işlemi
        public IActionResult GetQuestionsByID(int id)
        {
            var soru = _questionService.TGetById(id);
            var value = _mapper.Map<ResultQuestionDto>(soru);
            return Ok(value);
        }

        [HttpDelete("{id}")]  // id ye göre silme işlemi yapıyoruz
        public IActionResult DeleteQuestionss(int id)
        {
            _questionService.TDelete(id);
            return Ok("Kayıt başarılı bir şekilde silindi.");
        }

        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionDto model)
        {
            var soru = _mapper.Map<Questions>(model); //model ile sınıfı mapledik
            _questionService.TCreate(soru);
            return Ok("Kayıt başarılı bir şekilde eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateQuestionss(UpdateQuestionDto model)
        {
            var soru = _mapper.Map<Questions>(model); //yine aynı şekilde güncelleme işlemi için mapleme işlemi yaptık
            _questionService.TUpdate(soru);
            return Ok("Kayıt başarılı bir şekilde güncellendi");
        }
    }
}
