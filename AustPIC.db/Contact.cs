//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AustPIC.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public System.DateTime ContactTime { get; set; }
        public int ContactReplied { get; set; }
        public string ContactSubject { get; set; }
    }
}