using Microsoft.AspNetCore.Mvc;

namespace Portfolio_II.Controllers
{
    public class PortfolioController : Controller
    {
        [Route("/")]
        [HttpGet]
        public ViewResult Home()
        {
            return View("Home");
        }

        [Route("projects")]
        [HttpGet]
        public ViewResult Projects()
        {
            return View("Projects");
        }

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}