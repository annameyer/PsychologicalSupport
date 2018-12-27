namespace PsychologicalSupports.Models
{
    public class Archive
    {

        public int ArchiveID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public ClassroomRelationships ClassroomRelationshipsID { get; set; }
        public ClassTeacheInformation ClassTeacheInformationID { get; set; }
        public FamilyAlarmAnalysis FamilyAlarmAnalysisID { get; set; }
        public Intellectual_6_Class Intellectual_6_ClassID { get; set; }
        public Intellectual_7_Class Intellectual_7_ClassID { get; set; }
        public Intellectual_8_Class Intellectual_8_ClassID { get; set; }
        public Intellectual_9_Class Intellectual_9_ClassID { get; set; }
        public PersonaAnxietyScale PersonaAnxietyScaleID { get; set; }
        public Self_esteem Self_esteemID { get; set; }
        public SchoolMotivation SchoolMotivation { get; set; }
        public PersonalProtagonistAizenko PersonalProtagonistAizenko { get; set; }
        public PersonaAnxietyScale PersonaAnxietyScale { get; set; }
        public Mindset Mindset { get; set; }
        public InterestsInSchoolSubjects InterestsInSchoolSubjects { get; set; }
        public Interests_Card_145 Interests_Card_145 { get; set; }
        public Interests_Card_50 Interests_Card_50 { get; set; }
        public FamilyAlarmAnalysis FamilyAlarmAnalysis { get; set; }
        public EmotioTest EmotioTest { get; set; }
        public Test Test { get; set; }
    }
}