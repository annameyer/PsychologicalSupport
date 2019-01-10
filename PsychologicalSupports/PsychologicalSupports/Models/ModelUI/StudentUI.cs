﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologicalSupports.Models.ModelUI
{     [Table ("Учащиеся")]
    public class StudentUI
    {
        [Key]
        public long StudentID { get; set; }
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Класс")]
        public Nullable<int> NumberClass { get; set; }
        public string Class { get; set; }
        [Display(Name = "Дата поступления")]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AdmissionDate { get; set; }
        [Display(Name = "Обучается")]
        public Nullable<bool> BeingTrained { get; set; }

        public virtual AveragePoint AveragePoint { get; set; }
        public virtual ClassroomRelationship ClassroomRelationship { get; set; }
        public virtual ClassTeacheInformation ClassTeacheInformation { get; set; }
        public virtual EmotioTest EmotioTest { get; set; }
        public virtual FamilyAlarmAnalysi FamilyAlarmAnalysi { get; set; }
        public virtual Intellectual_6_Class Intellectual_6_Class { get; set; }
        public virtual Intellectual_7_Class Intellectual_7_Class { get; set; }
        public virtual Intellectual_8_Class Intellectual_8_Class { get; set; }
        public virtual Intellectual_9_Class Intellectual_9_Class { get; set; }
        public virtual Interests_Card_145 Interests_Card_145 { get; set; }
        public virtual Interests_Card_50 Interests_Card_50 { get; set; }
        public virtual InterestsInSchoolSubject InterestsInSchoolSubject { get; set; }
        public virtual Mindset Mindset { get; set; }
        public virtual PersonaAnxietyScale PersonaAnxietyScale { get; set; }
        public virtual PersonalProtagonistAizenko PersonalProtagonistAizenko { get; set; }
        public virtual SchoolMotivation SchoolMotivation { get; set; }
        public virtual Self_esteem Self_esteem { get; set; }
        public object Modified { get; internal set; }
    }
}