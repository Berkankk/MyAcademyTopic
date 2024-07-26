using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.ManuelDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultManuelComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultManuelComponent(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5228/api/");
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultManuelDto>>("manuels");
            //Controller adını yazıyoruz parantez içine
            return View(values);
        }
    }
}
