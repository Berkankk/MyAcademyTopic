using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultBlogComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultBlogComponent(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5228/api/");
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

            ViewBag.categories = categories;

            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
    }
}
