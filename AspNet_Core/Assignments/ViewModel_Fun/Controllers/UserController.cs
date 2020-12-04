using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers
{
    public class ViewModel_Fun : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            User bacon = new User()
            {
                Message = "Spicy jalapeno jerky beef ribs pastrami chicken salami landjaeger short loin short ribs picanha spare ribs turkey. Capicola pancetta alcatra, frankfurter beef cow flank spare ribs rump. Andouille prosciutto picanha burgdoggen. Chicken picanha ham, leberkas andouille ground round frankfurter shankle cupim corned beef pastrami pig chuck."
            };
            return View("Home", bacon);
        }
        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            return View("Numbers", numbers);
        }
        [HttpGet]
        [Route("users")]
        public IActionResult Users()
        {
            User user1 = new User()
            {
                FirstName = "Chris",
                LastName = "Hatfield",
            };
            User user2 = new User()
            {
                FirstName = "Jackie",
                LastName = "Kershner",
            };
            User user3 = new User()
            {
                FirstName = "Sandra",
                LastName = "Dickson",
            };
            List<User> people = new List<User>(){
                user1,
                user2,
                user3
            };
            return View("Users", people);
        }
        [HttpGet]
        [Route("user")]
        public IActionResult Person()
        {
            User user1 = new User()
            {
                FirstName = "Chris",
                LastName = "Hatfield"
            };
            return View("Person", user1);
        }
    }
}