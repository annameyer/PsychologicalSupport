//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsychologicalSupports.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mindset
    {
        public long MindsetID { get; set; }
        public long StudentID { get; set; }
        public string Subject_Effective { get; set; }
        public string AbstractSymbolic { get; set; }
        public string Verbal_Logical { get; set; }
        public string Visually_Shaped { get; set; }
        public string Creativity { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
