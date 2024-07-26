using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultCategoryComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultCategoryComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("http://localhost:5228/api/categories/GetActiveCategories");
            return View(values);

            //Gelen verileri json formatta okyor liste olarak deserilaze ediyor

        }
    }
}
