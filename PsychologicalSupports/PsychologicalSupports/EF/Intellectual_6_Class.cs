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
    
    public partial class Intellectual_6_Class
    {
        public long Intellectual_6_ClassID { get; set; }
        public long StudentID { get; set; }
        public Nullable<int> TestResult { get; set; }
        public string TestLevel { get; set; }
        public Nullable<double> AveragePoint { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
