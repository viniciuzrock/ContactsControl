﻿using Microsoft.AspNetCore.Mvc;

namespace ContactsControl.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
