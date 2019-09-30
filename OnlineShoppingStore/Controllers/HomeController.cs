using Newtonsoft.Json;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        TBmEntities ctx = new TBmEntities();
        public ActionResult Index(string search, int? page)
        {
            HomeIndexVM model = new HomeIndexVM();
            return View(model.CreateModel(search,4,page));
        }
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.Inventories.Find(productId);
                cart.Add(new Item()
                {
                    Inventory = product,
                    Inventory_Quantity = 1
                });
               
                Session["cart"] = cart;
                //ScriptManager.RegisterStartupScript(this,this.GetType(), "popup", "alert('Item added to cart');", true);
                //Response.Write("Item added to cart");
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = ctx.Inventories.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Inventory.Inventory_ID == productId)
                    {
                        int prevQty = cart[i].Inventory_Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Inventory = product,
                            Inventory_Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Inventory.Inventory_ID == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Inventory = product,
                                Inventory_Quantity = 1
                                
                        });
                        }
                        
                    }
                }
                Session["cart"] = cart;

               
            }
            //ViewBag.Message = "Item added to cart";
            return Redirect("Index");
        }

        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.Inventories.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Inventory.Inventory_ID == productId)
                    {
                        int prevQty = item.Inventory_Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Inventory = product,
                                Inventory_Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Checkout");
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
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult CheckoutDetail()
        {
           
            return View("CheckoutDetail");
        }


        //[HttpPost]
        public ActionResult Contact(/*OnlineShoppingStore.Models.Mail model*/)
        {
            //MailMessage msg = new MailMessage("itumeleng.morei@gmail.com", "u15128271@tuks.co.za");
            //msg.Subject = model.Subject;
            //msg.Body = model.Body;
            //msg.IsBodyHtml = false;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;

            //NetworkCredential nc = new NetworkCredential("itumeleng.morei@gmail.com", "CATHRINe13");
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = nc;
            //smtp.Send(msg);
            //string SendEmail = ConfigurationManager.AppSettings["SendEmail"];
            //if(SendEmail.ToLower() == "true")
            //{
            //    SendEmail(Exception)
            //}

            ViewBag.Message = "Email Succesfully sent";
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Location()
        {
            return View();
        }
      
        public static void SendEmail(string emailBody)
        {
            MailMessage msg = new MailMessage("itumeleng.morei@gmail.com", "u15128271@tuks.co.za");
            msg.Subject = "TBM";
            msg.Body = emailBody;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "itumeleng.morei@gmail.com",
                Password = "CATHRINe13"
            };
            smtp.EnableSsl = true;
            smtp.Send(msg);
            
        }

    }
}