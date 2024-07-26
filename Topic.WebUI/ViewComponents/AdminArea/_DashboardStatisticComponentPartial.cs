using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.ViewComponents.AdminArea
{
    public class _DashboardStatisticComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DashboardStatisticComponentPartial(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessageForBlogCount = await _httpClient.GetAsync("http://localhost:5228/api/Blogs/GetBlogCount");
            if (responseMessageForBlogCount.IsSuccessStatusCode) //başarılı ise 
            {
                var result = await responseMessageForBlogCount.Content.ReadAsStringAsync();
                ViewBag.BlogCount = result;
            }
            var responseMessageForAllCategoryCount = await _httpClient.GetAsync("http://localhost:5228/api/Categories/GetAllCategoryCount");

            if(responseMessageForAllCategoryCount.IsSuccessStatusCode)
            {
                var result = await responseMessageForAllCategoryCount.Content.ReadAsStringAsync();
                ViewBag.AllCategoryCount = result;
            }

            var responseMessageForActiveCategoryCount = await _httpClient.GetAsync("http://localhost:5228/api/Categories/GetActiveCategoryCount");
            if (responseMessageForActiveCategoryCount.IsSuccessStatusCode)
            {
                var result = await responseMessageForActiveCategoryCount.Content.ReadAsStringAsync();
                ViewBag.ActiveCategoryCount = result;
            }

            return View();
        }
    }
}
