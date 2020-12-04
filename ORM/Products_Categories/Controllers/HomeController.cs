using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Products_Categories.Models;
using Microsoft.AspNetCore.Identity;

namespace Products_Categories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("products/{ProductId}")]
        public IActionResult ProductPage(int ProductId)
        {
            ViewBag.oneProduct = _context.Products
                .Include(p => p.Associations)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == ProductId);
            ViewBag.AllCategoriesofProduct = _context.Categories
                .Include(c => c.Associations)
                .ThenInclude(a => a.Product)
                .Where( c => c.Associations.Any(a => a.ProductId == ProductId));
            ViewBag.AllCategoriesNotInProduct = _context.Categories
                .Include(c => c.Associations)
                .ThenInclude(a => a.Product)
                .Where(c => !c.Associations.Any(a => a.ProductId == ProductId));
            return View("Product");
        }

        [HttpGet("categories/{CategoryId}")]
        public IActionResult CategoryPage(int CategoryId)
        {
            ViewBag.oneCategory = _context.Categories
                .Include(c => c.Associations)
                .ThenInclude(a => a.Product)
                .FirstOrDefault(c => c.CategoryId == CategoryId);
            ViewBag.AllProductsOfCategory = _context.Products
                .Include(p => p.Associations)
                .Where(c => c.Associations.Any( a => a.CategoryId == CategoryId)).ToList();
            ViewBag.AllProductsNotInCategory = _context.Products
                .Include(p => p.Associations)
                .Where(c => !c.Associations.Any( a => a.CategoryId == CategoryId)).ToList();
            return View("Category");
        }

        [HttpGet("products")]
        public IActionResult ProductForm()
        {
            ViewBag.AllProducts = _context.Products;
            return View("AddProduct");
        }

        [HttpGet("categories")]
        public IActionResult CategoryForm()
        {
            ViewBag.AllCategories = _context.Categories;
            return View("AddCategory");
        }

//--------------------------POST Requests-----------------------------------

        [HttpPost("categories")]
        public IActionResult NewCategory(Category categoryForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryForm);
                _context.SaveChanges();
                return RedirectToAction("CategoryForm");
            }
            else
            {
                return View("AddCategory");
            }
        }

        [HttpPost("categories/{CategoryId}")]
        public IActionResult ProductToCategory(int CategoryId, Association aForm )
        {
            if (_context.Associations.Any(c => c.CategoryId == CategoryId && c.ProductId == aForm.ProductId))
            {
                return View("Category");
            }
            else
            {
                aForm.CategoryId = CategoryId;
                _context.Add(aForm);
                _context.SaveChanges();
                return RedirectToAction("CategoryForm");
            }
        }

        [HttpPost("products")]
        public IActionResult NewProduct(Product productForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productForm);
                _context.SaveChanges();
                return RedirectToAction("ProductForm");
            }
            else
            {
                return View("Product");
            }
        }

        [HttpPost("products/{ProductId}")]
        public IActionResult CategoryToProduct(int ProductId, Association aForm)
        {
            if ( _context.Associations.Any(p => p.ProductId == ProductId && p.CategoryId == aForm.CategoryId))
            {
                return View("AddProduct");
            }
            else
            {
                aForm.ProductId = ProductId;
                _context.Add(aForm);
                _context.SaveChanges();
                return RedirectToAction("ProductForm");
            }
        }

    }
}