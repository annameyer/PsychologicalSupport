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

    [Table("Тест эмоций")]
    public partial class EmotioTest
    {
        [key]
        public long StudentID { get; set; }

        [Display(Name = "Физическая агрессия")]
        public string PhysicalAggression { get; set; }
        [Display(Name = "Косвенная агрессия")]
        public string IndirectAggression { get; set; }
        [Display(Name = "Раздражительнось")]
        public string Irritability { get; set; }
        [Display(Name = "Негативизм")]
        public string Negativism { get; set; }
        [Display(Name = "Обидчивость")]
        public string Touchiness { get; set; }
        [Display(Name = "Подозрительность")]
        public string Suspicion { get; set; }
        [Display(Name = "Вербальная агрессия")]
        public string VerbalAggression { get; set; }
        [Display(Name = "Чувство вины")]
        public string Guilt { get; set; }

        public virtual Student Student { get; set; }
    }
}
