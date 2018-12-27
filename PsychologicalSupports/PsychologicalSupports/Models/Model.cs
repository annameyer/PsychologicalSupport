namespace PsychologicalSupports.Models.Db
{
    using System.Data.Entity;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=School")
        {
        }

        public virtual DbSet<Administrator> AdministratorIDs { get; set; }
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
        public virtual DbSet<Mindset> Mindsets { get; set; }
        public virtual DbSet<PersonaAnxietyScale> PersonaAnxietyScales { get; set; }
        public virtual DbSet<PersonalProtagonistAizenko> PersonalProtagonistAizenkoes { get; set; }
        public virtual DbSet<SchoolMotivation> SchoolMotivations { get; set; }
        public virtual DbSet<Self_esteem> Self_esteem { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Class)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.AveragePoints)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.ClassroomRelationships)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.ClassTeacheInformations)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.EmotioTests)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.FamilyAlarmAnalysis)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Intellectual_7_Class)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Intellectual_8_Class)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Intellectual_9_Class)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Interests_Card_145)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Interests_Card_50)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.InterestsInSchoolSubjects)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Mindsets)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.PersonaAnxietyScales)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.PersonalProtagonistAizenkoes)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.SchoolMotivations)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Self_esteem)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
