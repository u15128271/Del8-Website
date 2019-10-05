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
using System.IO;
using System.Web.UI;

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

                TempData["alertMessage"] = "Item added to cart";
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
            StringWriter sw = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(sw);
            //GridView1.RenderControl(ht);

            MailMessage mm = new MailMessage("itumeleng.morei@gmail.com", "scripters.inf370@gmail.com");
            mm.Body = "<h1>GridView Details</h1></br>" + sw.ToString();
            mm.Subject = "GridView data";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            System.Net.NetworkCredential nC = new System.Net.NetworkCredential("itumeleng.morei@gmail.com", "CATHRINe17");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nC;
            //var password = "CATHRINe13";
            smtp.Send(mm);
            return View();
        }
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //}
        [HttpPost]
        public ActionResult Contact(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("itumeleng.morei@gmail.com", "CATHRINe17");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "CATHRINe13";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }



        public ActionResult Contact(/*OnlineShoppingStore.Models.Mail model*/)
        {
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
      
        


        
    }
}