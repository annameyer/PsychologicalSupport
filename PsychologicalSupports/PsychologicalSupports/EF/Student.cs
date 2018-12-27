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
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.AveragePoints = new HashSet<AveragePoint>();
            this.ClassroomRelationships = new HashSet<ClassroomRelationship>();
            this.ClassTeacheInformations = new HashSet<ClassTeacheInformation>();
            this.EmotioTests = new HashSet<EmotioTest>();
            this.FamilyAlarmAnalysis = new HashSet<FamilyAlarmAnalysi>();
            this.Intellectual_6_Class = new HashSet<Intellectual_6_Class>();
            this.Intellectual_7_Class = new HashSet<Intellectual_7_Class>();
            this.Intellectual_8_Class = new HashSet<Intellectual_8_Class>();
            this.Intellectual_9_Class = new HashSet<Intellectual_9_Class>();
            this.Interests_Card_145 = new HashSet<Interests_Card_145>();
            this.Interests_Card_50 = new HashSet<Interests_Card_50>();
            this.InterestsInSchoolSubjects = new HashSet<InterestsInSchoolSubject>();
            this.Mindsets = new HashSet<Mindset>();
            this.PersonaAnxietyScales = new HashSet<PersonaAnxietyScale>();
            this.PersonalProtagonistAizenkoes = new HashSet<PersonalProtagonistAizenko>();
            this.SchoolMotivations = new HashSet<SchoolMotivation>();
            this.Self_esteem = new HashSet<Self_esteem>();
        }
    
        public long StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public Nullable<int> NumberClass { get; set; }
        public string Class { get; set; }
        public Nullable<System.DateTime> AdmissionDate { get; set; }
        public Nullable<bool> BeingTrained { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AveragePoint> AveragePoints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassroomRelationship> ClassroomRelationships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassTeacheInformation> ClassTeacheInformations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmotioTest> EmotioTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyAlarmAnalysi> FamilyAlarmAnalysis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intellectual_6_Class> Intellectual_6_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intellectual_7_Class> Intellectual_7_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intellectual_8_Class> Intellectual_8_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intellectual_9_Class> Intellectual_9_Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interests_Card_145> Interests_Card_145 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interests_Card_50> Interests_Card_50 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterestsInSchoolSubject> InterestsInSchoolSubjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mindset> Mindsets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaAnxietyScale> PersonaAnxietyScales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalProtagonistAizenko> PersonalProtagonistAizenkoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolMotivation> SchoolMotivations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Self_esteem> Self_esteem { get; set; }
    }
}
