//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisasterReliefFund.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonetaryDonation
    {
        public int DisasterDonorID { get; set; }
        public Nullable<int> DisasterID { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string status { get; set; }
    
        public virtual Disaster Disaster { get; set; }
    }
}
