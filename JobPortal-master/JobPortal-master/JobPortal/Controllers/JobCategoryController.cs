﻿using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
