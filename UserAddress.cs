//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banking
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAddress
    {
        public Nullable<short> CustomerID { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public Nullable<bool> IsPermanent { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}