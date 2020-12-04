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
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("User");
            if (UserId == null)
            {
                return RedirectToAction("Registration", "LogReg");
            }
            else
            {
                ViewBag.UserId = (int)HttpContext.Session.GetInt32("User");
                ViewBag.allWeddings = _context.Weddings
                    .Include(w => w.Guests)
                    .ThenInclude(g => g.User);
            
                
                return View("WeddingPlanner");
            }
        }

        [HttpGet("Wedding/{WeddingId}")]
        public IActionResult Details(int WeddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("User");

            if (UserId == null)
            {
                return RedirectToAction("Registration", "LogReg");
            }
            else
            {
                Wedding oneWedding = _context.Weddings
                    .Include(w => w.Guests)
                    .ThenInclude(g => g.User)
                    .FirstOrDefault(w => w.WeddingId == WeddingId);
                ViewBag.guestsAttending = _context.Users
                    .Include(u => u.Guests)
                    .ThenInclude(g => g.Wedding)
                    .Where(u => u.Guests.Any(w => w.WeddingId == WeddingId));
                return View("WeddingDetails", oneWedding);
            }
            
        }

        [HttpGet("Wedding")]
        public IActionResult NewWedding()
        {
            int? userId = HttpContext.Session.GetInt32("User");

            if (userId == null)
            {
                return RedirectToAction("Registration", "LogReg");
            }
            else
            {
                return View("WeddingForm");
            }
        }

        [HttpPost("Wedding/New")]
        public IActionResult AddWedding(Wedding wedForm)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");
            if (ModelState.IsValid)
            {
                if(wedForm.Date.Ticks <= DateTime.Now.Ticks)
                {
                    ModelState.AddModelError("Date", "Wedding Date must be in the Future.");
                    return View("WeddingForm");
                }
                else
                {
                    wedForm.UserId = UserId;
                    _context.Add(wedForm);
                    _context.SaveChanges();
                    return Redirect($"/Wedding/{wedForm.WeddingId}");
                }
            }
            else
            {
                return View("WeddingForm");
            }
        }

        [HttpGet("Dashboard/{WeddingId}")]
        public IActionResult AddGuest(int WeddingId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");
            if (_context.Guests.Any(g => g.UserId == UserId && g.WeddingId == WeddingId))
            {
                return View("WeddingPlanner");
            }
            else
            {
                Guest addGuest = new Guest();
                addGuest.WeddingId = WeddingId;
                addGuest.UserId = UserId;
                _context.Add(addGuest);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("Dashboard/{WeddingId}/Remove")]
        public IActionResult RemoveGuest(int WeddingId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("User");
            if (_context.Guests.Any(g => g.UserId == UserId && g.WeddingId == WeddingId))
            {
                Guest removeGuest = _context.Guests.FirstOrDefault(g => g.UserId == UserId && g.WeddingId == WeddingId);
                _context.Remove(removeGuest);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("WeddingPlanner");
            }
        }

        [HttpGet("Dashboard/{WeddingId}/{UserId}")]
        public IActionResult DeleteWedding(int WeddingId, int UserId)
        {
            Wedding deleteWedding = _context.Weddings.FirstOrDefault(w => w.UserId == UserId && w.WeddingId == WeddingId);
            
            _context.Remove(deleteWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}