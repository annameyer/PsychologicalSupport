namespace PsychologicalSupports.Models
{
    using PsychologicalSupports.Models.Dependencies;
    using System.Data.Entity;

    public partial class PsychologicalSupportsEntities : DbContext, IPsychologicalSupportsContext
    {
        public PsychologicalSupportsEntities()
            : base("name=PsychologicalSupport")
        {
        }

        public virtual DbSet<AveragePoint> AveragePoints { get; set; }
        public virtual DbSet<ClassroomRelationship> ClassroomRelationships { get; set; }
        public virtual DbSet<ClassTeacheInformation> ClassTeacheInformations { get; set; }
        public virtual DbSet<EmotioTest> EmotioTests { get; set; }
        public virtual DbSet<FamilyAlarmAnalysi> FamilyAlarmAnalysis { get; set; }
        public virtual DbSet<Intellectual_6_Class> Intellectual_6_Class { get; set; }
        public virtual DbSet<Intellectual_7_Class> Intellectual_7_Class { get; set; }
        public virtual DbSet<Intellectual_8_Class> Intellectual_8_Class { get; set; }
        public virtual DbSet<Intellectual_9_Class> Intellectual_9_Class { get; set; }
        public virtual DbSet<Interests_Card_145> Interests_Card_145 { get; set; }
        public virtual DbSet<Interests_Card_50> Interests_Card_50 { get; set; }
        public virtual DbSet<InterestsInSchoolSubject> InterestsInSchoolSubjects { get; set; }
        public virtual DbSet<PersonaAnxietyScale> PersonaAnxietyScales { get; set; }
        public virtual DbSet<PersonalProtagonistAizenko> PersonalProtagonistAizenkoes { get; set; }
        public virtual DbSet<SchoolMotivation> SchoolMotivations { get; set; }
        public virtual DbSet<Self_esteem> Self_esteem { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
