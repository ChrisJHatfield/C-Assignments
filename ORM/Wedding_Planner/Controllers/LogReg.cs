using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class LogRegController : Controller
    {
        private MyContext _context;

        public LogRegController(MyContext context)
        {
            _context = context;
        }

        
        [HttpGet("")]
        public IActionResult Registration()
        {
            return View("RegLog");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Registration", "LogReg");
        }

        [HttpPost("register")]
        public IActionResult Register(User userForm)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == userForm.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("RegLog");
                }
                else if (userForm.Password != userForm.Confirm)
                {
                    ModelState.AddModelError("Confirm", "Confirm password does not match Password");
                    return View("RegLog");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    userForm.Password = Hasher.HashPassword(userForm, userForm.Password);
                    userForm.CreatedAt = DateTime.Now;
                    userForm.UpdatedAt = DateTime.Now;
                    _context.Add(userForm);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("User", userForm.UserId);
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                return View("RegLog");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Login loginForm)
        {
            if (ModelState.IsValid)
            {
                var userExists = _context.Users.FirstOrDefault(u => u.Email == loginForm.UserEmail);

                if (userExists == null)
                {
                    ModelState.AddModelError("UserEmail", "Invalid Email or Password.");
                    return View("RegLog");
                }

                var Hasher = new PasswordHasher<Login>();
                var Result = Hasher.VerifyHashedPassword(loginForm, userExists.Password, loginForm.UserPassword);

                if (Result == 0)
                {
                    ModelState.AddModelError("UserPassword", "Invalid Email or Password");
                    return View("RegLog");
                }
                HttpContext.Session.SetInt32("User", userExists.UserId);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View("RegLog");
            }
        }
    }
}