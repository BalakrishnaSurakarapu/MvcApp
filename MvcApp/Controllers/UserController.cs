﻿using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
