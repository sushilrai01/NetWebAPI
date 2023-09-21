//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DriverTable
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> IsActive { get; set; }
        public string Hobby { get; set; }
        public Nullable<bool> Football { get; set; }
        public Nullable<bool> Cricket { get; set; }
        public Nullable<bool> Basketball { get; set; }
        public Nullable<bool> Singing { get; set; }
        public Nullable<bool> Dancing { get; set; }
        public Nullable<bool> Reading { get; set; }
        public Nullable<bool> Travelling { get; set; }
        public string ImageFilePath { get; set; }
        public string DocFilePath { get; set; }
    
        public virtual ActivityTable ActivityTable { get; set; }
        public virtual GenderTable GenderTable { get; set; }
    }
}
