using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Login_Registration.Models;

namespace Login_Registration.Controllers
{
    public class LogRegController : Controller
    {

        private MyContext _context;
        public LogRegController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home", "Home");
        }

        [HttpPost("user/create")]
        public IActionResult CreateUser(LogReg User)
        {
            if (ModelState.IsValid)
            {
                if (_context.LogsRegs.Any(u => u.Email == User.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("RegistrationPage", "Home");
                }
                    PasswordHasher<LogReg> Hasher = new PasswordHasher<LogReg>();
                    User.Password = Hasher.HashPassword(User, User.Password);
                    User.CreatedAt = DateTime.Now;
                    User.UpdatedAt = DateTime.Now;
                    _context.Add(User);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("User", User.LogRegId);
                    return RedirectToAction("Success", "Home");
            }
            else
            {
                return View("RegistrationPage", "Home");
            }
        }

        [HttpPost("user/login")]
        public IActionResult Login(LoginUser UserSub)
        {

            if (ModelState.IsValid)
            {
                var userInDb = _context.LogsRegs.FirstOrDefault( u => u.Email == UserSub.Email);
                
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password!");
                    return View("LoginPage", "Home");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(UserSub, userInDb.Password, UserSub.Password);
                
                if (result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email or Password!");
                    return View("LoginPage");
                }
                HttpContext.Session.SetInt32("User", userInDb.LogRegId);
                return RedirectToAction("Success", "Home");
            }
            else
            {
                return View("LoginPage", "Home");
            }
        }
        
    }
}