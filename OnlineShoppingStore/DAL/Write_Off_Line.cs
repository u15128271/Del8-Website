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
    
    public partial class Write_Off_Line
    {
        public int Write_Off_ID { get; set; }
        public int Inventory_ID { get; set; }
        public Nullable<System.DateTime> Write_Off_Date { get; set; }
        public string Write_Off_Reason { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual Write_Off_Stock Write_Off_Stock { get; set; }
    }
}