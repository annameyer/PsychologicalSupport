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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PersonaAnxietyScale
    {
        [Key]
        [ForeignKey("Student")]
        public long StudentID { get; set; }

        [Display(Name = "Школьная")]
        public string School { get; set; }
        [Display(Name = "Межличностная")]
        public string Interpersonal { get; set; }
        [Display(Name = "Самооценочная")]
        public string Self_assessment { get; set; }
        [Display(Name = "Общая")]
        public string General { get; set; }

        public virtual Student Student { get; set; }
    }
}
