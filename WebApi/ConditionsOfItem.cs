//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConditionsOfItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConditionsOfItem()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int ConditionType { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
    
        public virtual Apartment Apartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ConditionType ConditionType1 { get; set; }
    }
}
