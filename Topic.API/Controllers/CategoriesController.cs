using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.CategoryDtos;
using Topic.DTOLayer.Dtos.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]  //Listeleme işlemi yapar
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.TGetList(); //Burada value değeri category entitysini döndüğü için tekrardan bir constructor yaparak resultcategorydto döndürülmesini sağladık
            var categories = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(categories); //Burası 200 durum kodududr

        }

        [HttpGet("{id}")] //Bir controller içerisinde birden fazla aynı anda get isteği bulunamadığı için id parametresini atadık
        public IActionResult GetCategoryById(int id)
        {
            var value = _categoryService.TGetById(id);
            var category = _mapper.Map<ResultCategoryDto>(value);
            return Ok(category); //200 başarılı durum kodu
        }

        [HttpDelete("{id}")]   //id ye göre silme işlemi
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);  //Geriye bir şey dönmez
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPost]  //EKleme işlemini yaptık
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);  //Parametreyi entitye mapledik

            _categoryService.TCreate(category);
            return Ok("Kategori başarıyla oluşturuldu");
        }

        [HttpPut]   //Güncelleme işlemi
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _categoryService.TGetActiveCategories();
            //sorguyu dal ve business katmanında yaptığımız için burada sorgu yapmamıa gerek kalmadı
            var mappedResult = _mapper.Map<List<ResultCategoryDto>>(values);
            // REsultcategorydto yu values mapledik ve buradan aktif olan alanlar gelecek
            return Ok(mappedResult);
        }

    }
}