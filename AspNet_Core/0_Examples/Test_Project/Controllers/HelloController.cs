using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Test_Project.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("hello")]
        public string Hello()
        {
            return "Hello Again!";
        }
    }
}