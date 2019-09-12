using Newtonsoft.Json;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Dashboard()
        {
            return View();
        }


        
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Inventory>().GetProduct());
        }
        public ActionResult ProductEdit(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Inventory>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(Inventory tbl)
        {
            _unitOfWork.GetRepositoryInstance<Inventory>().Update(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Inventory tbl)
        {
            _unitOfWork.GetRepositoryInstance<Inventory>().Add(tbl);
            return RedirectToAction("Product");
        }
    }
}