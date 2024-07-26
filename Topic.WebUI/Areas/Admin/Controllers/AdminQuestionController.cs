﻿using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.QuestionsDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AdminQuestionController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminQuestionController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5228/api/");
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultQuestionDto>>("Questions");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto model)
        {
            await _httpClient.PostAsJsonAsync("Questions", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateQuestionDto>("Questions" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto model)
        {
            await _httpClient.PutAsJsonAsync("Questions", model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _httpClient.DeleteAsync("Questions/" + id);
            return RedirectToAction("Index");
        }
    }
}

