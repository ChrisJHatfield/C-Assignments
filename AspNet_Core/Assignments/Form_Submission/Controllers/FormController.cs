using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Form_Submission.Models;

namespace Form_Submission.Controllers
{
    public class FormController: Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Form()
        {
            return View("Form");
        }

        [HttpPost("")]
        public IActionResult FormSubmit(User newUser)
        {
            if (ModelState.IsValid)
            {
                return Redirect("success");
            }
            else
            {
                return View("Form");
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("Success");
        }
    }
}