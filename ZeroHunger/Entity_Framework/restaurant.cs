//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public restaurant()
        {
            this.collect_requests = new HashSet<collect_requests>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email_address { get; set; }
        public string contact_number { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<collect_requests> collect_requests { get; set; }
    }
}
