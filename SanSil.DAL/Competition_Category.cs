//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SanSil.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Competition_Category
    {
        public int CompetitionId { get; set; }
        public int CategoryId { get; set; }
        public string GenderId { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
