﻿using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
