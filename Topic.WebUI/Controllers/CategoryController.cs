using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;
using X.PagedList.Extensions;

namespace Topic.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int currentPage = pageNumber ?? 1; // Eğer pageNumber null ise varsayılan olarak 1
            var value = await _httpClient.GetFromJsonAsync<List<ResultCategoryBlogWith>>("http://localhost:5228/api/Categories/GetActiveCategories");
            if (value != null)
            {
                ViewBag.count = value.Count;
            }
            return View(value.ToPagedList(currentPage, 5));
        }


    }
}
