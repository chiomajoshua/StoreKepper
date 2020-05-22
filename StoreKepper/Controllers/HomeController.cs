using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreKeeper.Data.DataTransferObject;
using StoreKeeper.Data.ViewModels;
using StoreKeeper.Domain.Contract;
using StoreKepper.Models;

namespace StoreKepper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserManager<UserDto> _userManager;

        public HomeController(ILogger<HomeController> logger, IUserManager<UserDto> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        #region Login
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnURL = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var result = await _userManager.Login(model);
                    
                    //if (result != null)
                    if(model.Email == "Administrator" && model.Password == "test")
                    {                        
                       _logger.LogInformation($"Login Successful for {model.Email}");
                       ViewData["msg"] = $"Welcome {model.Email.ToUpper()}";
                       HttpContext.Session.SetString("_userName", model.Email);
                       return RedirectToAction("Index", "Product", new { area = "" });
                    }
                    else
                    {
                        _logger.LogInformation($"Login Unsuccessful....");
                        TempData["msg"] = $"Authentication failed for {model.Email.ToUpper()}";
                    }
                }
                else
                {
                    _logger.LogInformation($"Invalid model state....", model);
                    ViewData["msg"] = $"Please fill out all fields";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.InnerException?.InnerException?.Message}");
            }
            return RedirectToAction(nameof(Login));
        }
        #endregion      
    }
}
