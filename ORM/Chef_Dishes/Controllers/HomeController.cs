using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Chef_Dishes.Models;

namespace Chef_Dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
// -------------------Returns VIEWS--------------------------
        [HttpGet("")]
        public IActionResult Home()
        {
            List<Chef> AllChefs = _context.Chefs
            .Include(d => d.ChefDishes)
            .ToList();
            return View("Chef", AllChefs);
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = _context.Dishes
            .Include(c => c.Chef)
            .ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet("new")]
        public IActionResult ChefForm()
        {
            return View("AddChef");
        }

        [HttpGet("dishes/new")]
        public IActionResult DishForm()
        {
            ViewBag.allChefs = _context.Chefs.ToList();
            return View("AddDish");
        }

// ------------------- Functions --------------------------

        [HttpPost("new")]
        public IActionResult NewChef(Chef chefForm)
        {
            int chefAge = DateTime.Now.Year - chefForm.Birthday.Year;
            int underEighteen = (DateTime.Now.Year - 18) - chefForm.Birthday.Year;

            if (ModelState.IsValid)
            {
                if (chefForm.Birthday > DateTime.Now.AddYears(-chefAge))
                {
                    ModelState.AddModelError("Birthday", "Date of Birth can't be in the future");
                    return View("AddChef");
                }
                if (underEighteen <= 0)
                {
                    ModelState.Remove("Birthday");
                    ModelState.AddModelError("Birthday", "A Chef must be 18 years or older!");
                    return View("AddChef");
                }
                else
                {
                    _context.Add(chefForm);
                    _context.SaveChanges();
                    return RedirectToAction("Home");
                }
            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpPost("dishes/new")]
        public IActionResult NewDish(Dish dishForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dishForm);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.allChefs = _context.Chefs.ToList();
                return View("AddDish");
            }
        }
    }
}