namespace PsychologicalSupports.Models
{
    public class SchoolMotivation
    {
        public int SchoolMotivationID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string StudyInClass { get; set; }
        public string TestFamilyStudiesLevel { get; set; }
        public string CognitiveInterest { get; set; }
        public string TesMotivationAchievementstLevel { get; set; }
        public string Classmates { get; set; }
        public string Pedagogues { get; set; }
        public string ByParents { get; set; }
        public string FromTheSideOfTheSchool { get; set; }
        public string FromTheSideOfTheFamily { get; set; }
        public string AwarenessOfSocialNecessity { get; set; }
        public string CommunicationMotif { get; set; }
        public string ExtracurricularSchoolMotivation { get; set; }
        public string TheMotiveOfSelf_Realization { get; set; }
    }
}