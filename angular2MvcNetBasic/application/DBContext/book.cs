//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryingAngular.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class book
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string authors { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string readbook { get; set; }
    }
}
