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
    
    public partial class Inventory_Level_Status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Level_Status()
        {
            this.Inventory_Level = new HashSet<Inventory_Level>();
        }
    
        public int InvLevel_Status_ID { get; set; }
        public string InvLevel_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Level> Inventory_Level { get; set; }
    }
}