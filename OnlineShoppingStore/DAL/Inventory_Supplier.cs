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
    
    public partial class Inventory_Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Supplier()
        {
            this.Inventory_Supplier_Order = new HashSet<Inventory_Supplier_Order>();
            this.Received_Supplier_Order = new HashSet<Received_Supplier_Order>();
        }
    
        public int InvSupplier_ID { get; set; }
        public string InvSupp_Name { get; set; }
        public string InvSupp_Address { get; set; }
        public string InvSupp_Email { get; set; }
        public Nullable<int> InvSupp_Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Supplier_Order> Inventory_Supplier_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Received_Supplier_Order> Received_Supplier_Order { get; set; }
    }
}
