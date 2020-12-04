using Microsoft.AspNetCore.Mvc;
using Multiple_Forms.Models;

namespace Multiple_Forms.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create/product")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost("create/user")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet("success")]
        public string Success()
        {
            return "You have successfully submitted!";
        }
    }
}