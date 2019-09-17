using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.DAL;

namespace OnlineShoppingStore.Models.Home
{
    public class Item
    {
        public Inventory Inventory { get; set; }
        public int Inventory_Quantity { get; set; }
    }
}