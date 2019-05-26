using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PsychologicalSupports.Models.Dependencies
{
    public interface IPsychologicalSupportsContext
    {
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbSet<Student> Students { get; set; }
        DbSet<AveragePoint> AveragePoints { get; set; }
        DbSet<ClassroomRelationship> ClassroomRelationships { get; set; }
        DbSet<ClassTeacheInformation> ClassTeacheInformations { get; set; }
        DbSet<EmotioTest> EmotioTests { get; set; }
        DbSet<FamilyAlarmAnalysi> FamilyAlarmAnalysis { get; set; }
        DbSet<Intellectual_6_Class> Intellectual_6_Class { get; set; }
        DbSet<Intellectual_7_Class> Intellectual_7_Class { get; set; }
        DbSet<Intellectual_8_Class> Intellectual_8_Class { get; set; }
        DbSet<Intellectual_9_Class> Intellectual_9_Class { get; set; }
        DbSet<Interests_Card_145> Interests_Card_145 { get; set; }
        DbSet<Interests_Card_50> Interests_Card_50 { get; set; }
        DbSet<InterestsInSchoolSubject> InterestsInSchoolSubjects { get; set; }
        DbSet<PersonaAnxietyScale> PersonaAnxietyScales { get; set; }
        DbSet<PersonalProtagonistAizenko> PersonalProtagonistAizenkoes { get; set; }
        DbSet<SchoolMotivation> SchoolMotivations { get; set; }
        DbSet<Self_esteem> Self_esteem { get; set; }

    }
}
