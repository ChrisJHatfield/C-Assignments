using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;

namespace Dojo_Survey.Controllers
{
    public class DojoSurvey: Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Survey()
        {
            return View("Survey");
        }
            
        [HttpPost("result")]
        public IActionResult result(Survey newResult)
        {
            if (ModelState.IsValid)
            {
                return View("Results", newResult);
            }
            else 
            {
                return View("Survey");
            }
        }
    }
}