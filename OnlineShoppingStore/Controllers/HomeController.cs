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
        TBMEntities ctx = new TBMEntities();
        public ActionResult Index(string search, int? page)
        {
            HomeIndexVM model = new HomeIndexVM();
            return View(model.CreateModel(search,3,page));
        }
        public ActionResult AddToCart(int productId)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.Inventories.Find(productId);
                cart.Add(new Item()
                {
                    Inventory = product,
                    Inventory_Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.Inventories.Find(productId);
                foreach(var item in cart)
                {
                    if(item.Inventory.Inventory_ID == productId)
                    {
                        int prevQty = item.Inventory_Quantity;
                        cart.Remove(item);
                        cart.Add(new Item()
                        {
                            Inventory = product,
                            Inventory_Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        cart.Add(new Item()
                        {
                            Inventory = product,
                            Inventory_Quantity = 1
                        });

                    }
                }
               
                Session["cart"] = cart;
            }
            
            return Redirect("Index");
        }

        public ActionResult RemoveFromCart ( int Inventory_ID)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            //var product = ctx.Inventories.Find(productId);
            foreach(var item in cart)
            {
                if(item.Inventory.Inventory_ID == Inventory_ID)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "About THE BOOK MARKET";

        //    return View("About");
        //}

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult CheckoutDetail()
        {
            return View();
        }

    }
}