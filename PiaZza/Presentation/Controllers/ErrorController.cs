﻿using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult NotFound()
        {
            return View("NotFound");
        }
        public ViewResult InternalServerError()
        {
            return View("InternalServerError");
        }
    }
}