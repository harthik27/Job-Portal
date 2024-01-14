using JobPortal.Models;
using JobPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register(string email,string password)
        {
            RegisterViewModel model = new RegisterViewModel() { Email = email, Password = password };
            var result = await _authService.Register(model.Email, model.Password);
            if (result)
            {

            }

            return View(model);
        }
    }
}
