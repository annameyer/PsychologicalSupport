namespace PsychologicalSupports.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public Student()
        {
            AveragePoints = new HashSet<AveragePoint>();
            ClassroomRelationships = new HashSet<ClassroomRelationship>();
            ClassTeacheInformations = new HashSet<ClassTeacheInformation>();
            EmotioTests = new HashSet<EmotioTest>();
            FamilyAlarmAnalysis = new HashSet<FamilyAlarmAnalysi>();
            Intellectual_7_Class = new HashSet<Intellectual_7_Class>();
            Intellectual_8_Class = new HashSet<Intellectual_8_Class>();
            Intellectual_9_Class = new HashSet<Intellectual_9_Class>();
            Interests_Card_145 = new HashSet<Interests_Card_145>();
            Interests_Card_50 = new HashSet<Interests_Card_50>();
            InterestsInSchoolSubjects = new HashSet<InterestsInSchoolSubject>();
            Mindsets = new HashSet<Mindset>();
            PersonaAnxietyScales = new HashSet<PersonaAnxietyScale>();
            PersonalProtagonistAizenkoes = new HashSet<PersonalProtagonistAizenko>();
            SchoolMotivations = new HashSet<SchoolMotivation>();
            Self_esteem = new HashSet<Self_esteem>();
        }

        public long StudentID { get; set; }

        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }

        public int? NumberClass { get; set; }

        [StringLength(10)]
        public string Class { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public bool? BeingTrained { get; set; }

        public virtual ICollection<AveragePoint> AveragePoints { get; set; }

        public virtual ICollection<ClassroomRelationship> ClassroomRelationships { get; set; }

        public virtual ICollection<ClassTeacheInformation> ClassTeacheInformations { get; set; }

        public virtual ICollection<EmotioTest> EmotioTests { get; set; }

        public virtual ICollection<FamilyAlarmAnalysi> FamilyAlarmAnalysis { get; set; }

        public virtual ICollection<Intellectual_7_Class> Intellectual_7_Class { get; set; }
        public virtual ICollection<Intellectual_8_Class> Intellectual_8_Class { get; set; }

        public virtual ICollection<Intellectual_9_Class> Intellectual_9_Class { get; set; }

        public virtual ICollection<Interests_Card_145> Interests_Card_145 { get; set; }

        public virtual ICollection<Interests_Card_50> Interests_Card_50 { get; set; }

        public virtual ICollection<InterestsInSchoolSubject> InterestsInSchoolSubjects { get; set; }

        public virtual ICollection<Mindset> Mindsets { get; set; }

        public virtual ICollection<PersonaAnxietyScale> PersonaAnxietyScales { get; set; }

        public virtual ICollection<PersonalProtagonistAizenko> PersonalProtagonistAizenkoes { get; set; }

        public virtual ICollection<SchoolMotivation> SchoolMotivations { get; set; }
        public virtual ICollection<Self_esteem> Self_esteem { get; set; }
    }
}
