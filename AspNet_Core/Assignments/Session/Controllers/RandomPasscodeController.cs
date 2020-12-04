using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Random_Passcode.Models;

namespace Random_Passcode.Controllers
{
    public class RandomPasscodeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("random")]
        public IActionResult NewRandom(PassCode newCode)
        {
            
            if(HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 1);
                ViewBag.Count = 1;
            }
            else{
                int myCount = (int)HttpContext.Session.GetInt32("count");
                myCount++;
                HttpContext.Session.SetInt32("count", myCount);
                ViewBag.Count = myCount;
            }
            
            HttpContext.Session.SetString("Code", newCode.RandomString);
            string myString = HttpContext.Session.GetString("Code");
            return View("Index", myString);
        }
    }
}