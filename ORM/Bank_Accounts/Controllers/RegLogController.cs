using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bank_Accounts.Models;

namespace Bank_Accounts.Controllers
{
    public class RegLogController : Controller
    {
        private MyContext _context;
        public RegLogController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View("Registration");
        }

        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View("Login");
        }

        [HttpPost("")]
        public IActionResult CreateUser(User userForm)
        {
            if (ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == userForm.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Registration");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                userForm.Password = Hasher.HashPassword(userForm, userForm.Password);
                userForm.CreatedAt = DateTime.Now;
                userForm.UpdatedAt = DateTime.Now;
                _context.Add(userForm);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("User", userForm.UserId);
                return Redirect($"account/{userForm.UserId}");
            }
            else
            {
                return View("Registration");
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(Login loginForm)
        {
            if (ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault( u => u.Email == loginForm.Email);

                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login");
                }

                var Hasher = new PasswordHasher<Login>();
                var Result = Hasher.VerifyHashedPassword(loginForm, userInDb.Password, loginForm.Password);

                if (Result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email or Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("User", userInDb.UserId);
                return Redirect($"account/{userInDb.UserId}");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }

    }
}