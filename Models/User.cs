//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IlmdostPanel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Applications = new HashSet<Application>();
        }
    
        public int user_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string father_name { get; set; }
        public string cv { get; set; }
        public string Image { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string experience { get; set; }
        public string cover_letter { get; set; }
        public string cnic { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Applications { get; set; }
    }
}
