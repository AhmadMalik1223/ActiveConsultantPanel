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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.Jobs = new HashSet<Job>();
            this.Departments = new HashSet<Department>();
        }
    
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string company_email { get; set; }
        public string company_address { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string company_owner { get; set; }
        public string company_contact { get; set; }
        public string company_about { get; set; }
        public string company_registration { get; set; }
        public Nullable<bool> company_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Jobs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
