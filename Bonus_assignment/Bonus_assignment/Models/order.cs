//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonus_assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        public int order_id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> item_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
    }
}