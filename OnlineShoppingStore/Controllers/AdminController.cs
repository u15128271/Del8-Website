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

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Inventory>().GetAllRecords();
            foreach(var item in cat)
            {
                list.Add(new SelectListItem { Value = item.Inventory_Description, Text= item.Inventory_Description });
            }

            return list;
        }



        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Inventory_Type> allcategories = _unitOfWork.GetRepositoryInstance<Inventory_Type>().GetAllRecordsIQueryable().ToList();
            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int InventoryType_ID)
        {
            CategoryDetail cd;
            if (InventoryType_ID != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Inventory_Type>().GetFirstorDefault(InventoryType_ID)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory", cd);

        }
        public ActionResult CategoryEdit(int catId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Inventory_Type>().GetFirstorDefault(catId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(Inventory_Type tbl)
        {
            _unitOfWork.GetRepositoryInstance<Inventory_Type>().Update(tbl);
            return RedirectToAction("Categories");
        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Inventory>().GetProduct());
        }
        public ActionResult ProductEdit(int Inventory_ID)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Inventory>().GetFirstorDefault(Inventory_ID));
        }
        [HttpPost]
        public ActionResult ProductEdit(Inventory tbl, HttpPostedFileBase file)
        {
            
                string pic = null;
                if (file != null)
                {
                    pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            _unitOfWork.GetRepositoryInstance<Inventory>().Update(tbl);
                return RedirectToAction("Product");
            
        }

        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Inventory tbl,HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            
            _unitOfWork.GetRepositoryInstance<Inventory>().Add(tbl);
            return RedirectToAction("Product");
        }
        
    }
}