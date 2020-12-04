using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Bank_Accounts.Models;
using Bank_Accounts.Controllers;

namespace Bank_Accounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("account/{UserId}")]
        public IActionResult AccountDetails(int UserId)
        {
            int? userId = HttpContext.Session.GetInt32("User");

            if (userId != UserId)
            {
                return RedirectToAction("Home", "RegLog");
            }
            else
            {
                ViewBag.sum = _context.Transactions
                    .Where(u => u.UserId == UserId).Sum(u => u.Amount);
                ViewBag.user = _context.Users
                    .Include(t => t.Balance)
                    .FirstOrDefault( u => u.UserId == UserId);

                ViewBag.balances = _context.Transactions
                .Include(u => u.User)
                .Where(u => u.UserId == UserId).OrderBy(u => u.CreatedAt);

                return View("Account");
            }
        }

        [HttpPost("account/{UserId}")]
        public IActionResult Transact(int UserId, Transaction transactionForm)
        {
            double sum = _context.Transactions
                .Where(u => u.UserId == UserId).Sum(u => u.Amount);

            ViewBag.user = _context.Users
                    .Include(t => t.Balance)
                    .FirstOrDefault( u => u.UserId == UserId);

            ViewBag.sum = _context.Transactions
                    .Where(u => u.UserId == UserId).Sum(u => u.Amount);

            if (ModelState.IsValid)
            {
                if(sum + transactionForm.Amount <= 0)
                {
                    ModelState.AddModelError("Amount", "You do not have enough money in your account!");
                    return View("Account");
                }
                else
                {
                    _context.Add(transactionForm);
                    _context.SaveChanges();
                    return RedirectToAction("AccountDetails");
                }
            }
            else
            {
                return View("Account");
            }
        }

    }
}