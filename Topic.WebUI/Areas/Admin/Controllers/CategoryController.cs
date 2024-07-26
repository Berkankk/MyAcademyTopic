using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;
        //Bu client nesnesi aracılığıyla isteğimizi atıyoruz. Bunu da programcs e geçmemiz lazım
        //Client nesnesi ile atılan isteklerin genelde hepsi  asenkron metotlardır

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //client istekler asenkron yapıdadır
        public async Task<IActionResult> Index()
        {
            var ResponseMessage = await _httpClient.GetAsync("http://localhost:5228/api/categories");
            //get isteği attık ve buradan bize durum kodu dönecek  durum kodu 200 dönerse if sorgusuna gireceğiz

            if (ResponseMessage.IsSuccessStatusCode)   //Response mesaj başarılı olursa 
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                //Gelen değerleri jsonData formatında okuduk
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                //Burada json formatı string formata dönüştürmek için deserilaze işlemi yaptık
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = JsonConvert.SerializeObject(createCategoryDto);
            //Gelen veriyi string formattan json formata serilaza ettik
            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");
            //Türkçe karakterler olduğu için encoding utf 8 yaptık
            var responseMessage = await _httpClient.PostAsync("http://localhost:5228/api/categories/", stringContent);

            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            //başarılı dönmezse 
            return View();
        }

        //Burada mvc üzerinde çalıştığımıız için httpdelete yazmamıza gerek kalmadı ama api tarafında hepsini yazmak zorundayız
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync("http://localhost:5228/api/categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)  //id parametresi ile birlikte get isteği yaptık
        {
            var httpResponseMessage = await _httpClient.GetAsync("http://localhost:5228/api/categories/" + id);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = JsonConvert.SerializeObject(updateCategoryDto);
            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("http://localhost:5228/api/categories/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
