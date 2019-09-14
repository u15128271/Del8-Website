using Newtonsoft.Json;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search)
        {
            HomeIndexVM model = new HomeIndexVM();
            return View(model.CreateModel(search));
        }

        public ActionResult About()
        {
            ViewBag.Message = "About THE BOOK MARKET";

            return View("About");
        }
       
    }
}