﻿using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobOfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
