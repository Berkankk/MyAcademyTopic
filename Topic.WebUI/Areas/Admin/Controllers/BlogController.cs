using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5228/api/");
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            //Bu metot url e istek atıyor ve json formatında alıyor ve mapleme işlemini de yapıyor , liste türünde mapleme işlemini yaptık
            //category controller da yazdığımız kodlara gerek kalmadı bu metotla diğer kontrollerda yazdığımız kod geleneksel koddu
            return View(value);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            //Categorydekilere erişmek için yazdık
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();

            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _httpClient.PostAsJsonAsync("blogs", createBlogDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            //Categorydekilere erişmek için yazdık
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();

            ViewBag.categories = categories;
            var value = await _httpClient.GetFromJsonAsync<UpdateBlogDto>("blogs" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlog)
        {
            await _httpClient.PutAsJsonAsync("blogs", updateBlog);
            return RedirectToAction("Index");
        }
    }
}
