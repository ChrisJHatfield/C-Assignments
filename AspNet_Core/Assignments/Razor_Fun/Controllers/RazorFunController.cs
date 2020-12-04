using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Razor_Fun.Controllers
{
    public class RazorFunController : Controller
    {
        [HttpGet]
        [Route("")]

        public ViewResult Index()
        {
            return View("Index");
        }
    }
}