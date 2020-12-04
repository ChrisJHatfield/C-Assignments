using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;
using System.Text.Json;

namespace Dojodachi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
    public class DojodachiController: Controller
    {
        [HttpGet("dojodachi")]
        public IActionResult petIndex()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null)
            {
                myPet = new DojodachiPet();
                HttpContext.Session.SetObjectAsJson("Pet", myPet);
            }
            return View("Index", myPet);
        }

        [HttpGet("dojodachi/feed")]
        public IActionResult Feed()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null)
            {
                return RedirectToAction("petIndex");
            }
            myPet.Feed();
            myPet.GameOver();
            HttpContext.Session.SetObjectAsJson("Pet", myPet);
            return RedirectToAction("petIndex");
        }

        [HttpGet("dojodachi/play")]
        public IActionResult Play()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null)
            {
                return RedirectToAction("petIndex");
            }
            myPet.Play();
            myPet.GameOver();
            HttpContext.Session.SetObjectAsJson("Pet", myPet);
            return RedirectToAction("petIndex");
        }

        [HttpGet("dojodachi/work")]
        public IActionResult Work()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null )
            {
                return RedirectToAction("petIndex");
            }
            myPet.Working();
            myPet.GameOver();
            HttpContext.Session.SetObjectAsJson("Pet", myPet);
            return RedirectToAction("petIndex");
        }

        [HttpGet("dojodachi/sleep")]
        public IActionResult Sleep()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null)
            {
                return RedirectToAction("petIndex");
            }
            myPet.Sleeping();
            myPet.GameOver();
            HttpContext.Session.SetObjectAsJson("Pet", myPet);
            return RedirectToAction("petIndex");
        }

        [HttpGet("dojodachi/restart")]
        public IActionResult Restart()
        {
            DojodachiPet myPet = HttpContext.Session.GetObjectFromJson<DojodachiPet>("Pet");
            if (myPet == null)
            {
                return RedirectToAction("petIndex");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("petIndex");
        }
    }
}