using Microsoft.AspNetCore.Mvc;

namespace Time_Display.Controllers
{
    public class TimeController : Controller
    {
        [Route("")]
        [HttpGet]

        public IActionResult Time()
        {
            return View("Time");
        }
    }
}