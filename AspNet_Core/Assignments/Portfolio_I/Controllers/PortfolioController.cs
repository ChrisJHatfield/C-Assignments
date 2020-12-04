using Microsoft.AspNetCore.Mvc;
namespace Portfolio_I.Controllers
{
    public class PortfolioController : Controller
    {
        [Route("")]
        [HttpGet]
        public string Index()
        {
            return "This is my Index!";
        }

        [Route("projects")]
        [HttpGet]

        public string Projects()
        {
            return "These are my projects";
        }

        [Route("contact")]
        [HttpGet]

        public string Contact()
        {
            return "This is my Contact!";
        }
        
    }
}