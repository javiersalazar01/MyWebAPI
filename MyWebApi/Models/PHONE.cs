//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHONE
    {
        public int phone_id { get; set; }
        public int student_id { get; set; }
        public string phone1 { get; set; }
        public string phone_type { get; set; }
        public string country_code { get; set; }
        public string area_code { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> updated_on { get; set; }
    
        public virtual STUDENT STUDENT { get; set; }
    }
}