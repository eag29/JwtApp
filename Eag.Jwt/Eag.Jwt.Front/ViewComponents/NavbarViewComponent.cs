﻿using Microsoft.AspNetCore.Mvc;

namespace Eag.Jwt.Front.ViewComponents
{
    public class NavbarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
