using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("admin")]
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
