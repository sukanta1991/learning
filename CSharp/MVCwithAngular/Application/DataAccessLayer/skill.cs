//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class skill
    {
        public int skillId { get; set; }
        public string skills { get; set; }
        public Nullable<bool> trained { get; set; }
        public Nullable<int> userId { get; set; }
    
        public virtual userDetail userDetail { get; set; }
    }
}
