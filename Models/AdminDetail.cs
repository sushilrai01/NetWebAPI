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
    
    public partial class AdminDetail
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> ActiveId { get; set; }
        public string Hobby { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> Football { get; set; }
        public Nullable<bool> Basketball { get; set; }
        public Nullable<bool> Singing { get; set; }
        public Nullable<bool> Travelling { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
    }
}
