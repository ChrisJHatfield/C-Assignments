using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
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
            List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            return View("Index", AllDishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("NewDish");
        }

        [HttpPost("submit")]
        public IActionResult CreateDish(Dish FormSubmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(FormSubmission);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpGet("{DishId}")]
        public IActionResult DishDetails(int DishId)
        {
            Dish singleDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            return View("DishDetails", singleDish);
        }

        [HttpGet("edit/{DishId}")]
        public IActionResult EditDishForm(int DishId)
        {
            Dish dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if (dishToEdit == null)
            {
                return RedirectToAction("Home");
            }
            return View("EditDish", dishToEdit);
        }

        [HttpPost("update/{DishId}")]
        public IActionResult EditDish(int DishId, Dish FormSubmission)
        {
            Dish dishEdited = _context.Dishes.SingleOrDefault(d => d.DishId == DishId);
            if (dishEdited == null)
            {
                return RedirectToAction("Home");
            }
            if (ModelState.IsValid)
            {
                dishEdited.Name = FormSubmission.Name;
                dishEdited.Chef = FormSubmission.Chef;
                dishEdited.Calories = FormSubmission.Calories;
                dishEdited.Tastiness = FormSubmission.Tastiness;
                dishEdited.Description = FormSubmission.Description;
                dishEdited.UpdatedAt = DateTime.Now;
                _context.Entry(FormSubmission).Property("CreatedAt").IsModified = false;
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            else
            {
                return View("EditDish", FormSubmission);
            }
        }

        [HttpGet("delete/{DishId}")]
        public IActionResult RemoveDish(int DishId)
        {
            Dish dishToRemove = _context.Dishes.SingleOrDefault(d => d.DishId == DishId);
            if (dishToRemove == null)
            {
                return RedirectToAction("Home");
            }
            _context.Remove(dishToRemove);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

    }
}