using Microsoft.AspNetCore.Mvc;

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
            
            
        [HttpPost]
        [Route("result")]
        public IActionResult result(string Name, string Location, string Language, string Comment)
        {
            string[] formInfo = new string[]{Name, Location, Language, Comment};
            ViewBag.Results = formInfo;
            return View("Results");
        }
    }
}