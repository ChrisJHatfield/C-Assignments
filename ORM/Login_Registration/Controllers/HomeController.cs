using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Login_Registration.Models;
using Login_Registration.Controllers;

namespace Login_Registration.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View("RegistrationPage");
        }

        [HttpGet("login")]
        public IActionResult UserLogin()
        {
            return View("LoginPage");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            int? userId = HttpContext.Session.GetInt32("User");
            if ( userId == null)
            {
                return RedirectToAction("Home");
            }
            else
            {
            return View("Success");
            }
        }

    }
}