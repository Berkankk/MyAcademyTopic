using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]  //blogları listele
        public IActionResult GetAllBlogs()
        {
            var values = _blogService.TGetBlogsWithCategories();  //Bu metot satesinde kategori kontrollerı ile birlilkte gelecek yani ilişkili bir tablo şeklinde gelecek
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);  //burada gelen değeri list olarak tuttuğumuz için list kullandık gelen veri çoğul gelecek 
            return Ok(blogs);
        }

        [HttpGet("GetBlogsByCategoryId/{id}")]

        public IActionResult GetBlogsByCategoryId(int id)
        {
            var values = _blogService.TGetBlogsByCategoryId(id);
            return Ok(values);
        }

        [HttpGet("{id}")]   //id ye göre listeleme işlemi yapıyoruz

        public IActionResult GetBlogByID(int id)
        {
            var value = _blogService.TGetBlogWithCategoryByID(id);
            var blog = _mapper.Map<ResultBlogDto>(value); //mapleme işlemi yaptık burada burada list kullanmadık çünkü id ye göre veri gelcek ve çoğul gelmeyecek
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _blogService.TDelete(id);
            return Ok("Başarılı bir şekilde silinmiştir.");
        }

        [HttpPost]

        public IActionResult CreateBlog(CreateBlogDto createBlog)
        {
            var blog = _mapper.Map<Blog>(createBlog);  //blog entitysini mapledik
            _blogService.TCreate(blog);
            return Ok("Blog başarılı bir şekilde oluşturuldu.");
        }

        [HttpPut]
        public IActionResult UpdateBlog(UpdateBlogDto updateBlog)
        {
            var blog = _mapper.Map<Blog>(updateBlog);
            _blogService.TUpdate(blog);
            return Ok("Blog başarılı bir şekilde güncellendi.");
        }


    }
}
