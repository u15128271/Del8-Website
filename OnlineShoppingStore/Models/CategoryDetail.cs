using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Models
{
    public class CategoryDetail
    {
        public int InventoryType_ID { get; set; }
        [Required(ErrorMessage ="Category Name Requird")]
        [StringLength(100, ErrorMessage ="Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength =3)]
        public string CategoryName { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        //public Nullable<bool> IsDelete { get; set; }
    }

    public class ProductDetail
    {
        public int Inventory_ID { get; set; }
        [Required(ErrorMessage ="Product Name is Required")]
        [StringLength(100,ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allowed",MinimumLength =3)]
        public string Inventory_Name { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> InventoryType_ID { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        //public Nullable<bool> IsDelete { get; set; }
        //public Nullable<System.DateTime> CreatedDate { get; set; }
        //public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage ="Description is Required")]
        public Nullable<System.DateTime> InventoryType_Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Required]
        [Range(typeof(int), "1","500",ErrorMessage ="Invalid Quantity")]
        public Nullable<int> Inventory_Quantity { get; set; }
        [Required]
        [Range(typeof(decimal),"1","200000",ErrorMessage ="invalid Price")]
        public Nullable<decimal> Inventory_Price { get; set; }
        public SelectList Categories { get; set; }
    }
}