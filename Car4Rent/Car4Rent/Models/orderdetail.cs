//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car4Rent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderdetail
    {
        public int Orderdetail_id { get; set; }
        public int Order_id { get; set; }
        public int Driver_id { get; set; }
        public int Employee_id { get; set; }
        public System.DateTime ProcessDate { get; set; }
    
        public virtual driver driver { get; set; }
        public virtual employee employee { get; set; }
        public virtual order order { get; set; }
    }
}