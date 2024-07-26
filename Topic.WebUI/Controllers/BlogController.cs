using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
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
            return View(value);
        }

        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            var blogsByCategory = value.Where(x => x.CategoryID == id).ToList();
            return View(blogsByCategory);
        }

        public async Task<IActionResult> GetBlogDetails(int id)  //blog detay sayfası
        {
            var values = await _httpClient.GetFromJsonAsync<ResultBlogDto>("blogs/" + id);
            return View(values);
        }
    }
}
