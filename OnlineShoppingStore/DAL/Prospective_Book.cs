//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingStore.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prospective_Book
    {
        public int ProsBook_ID { get; set; }
        public Nullable<int> BookSupplier_ID { get; set; }
        public Nullable<System.DateTime> ProsBook_Date { get; set; }
    
        public virtual Book_Supplier Book_Supplier { get; set; }
    }
}
