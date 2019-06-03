﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsychologicalSupports.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Intellectual_6_Class
    {
        [Key]
        [ForeignKey("Student")]
        [Display(Name = "Номер учащегося")]
        public long StudentID { get; set; }
        [Display(Name = "Результат в %")]
        public Nullable<int> TestResult { get; set; }
        [Display(Name = "Уровень")]
        public string TestLevel { get; set; }
        [Display(Name = "Средний балл")]
        public Nullable<double> AveragePoint { get; set; }

        public virtual Student Student { get; set; }
    }
}
