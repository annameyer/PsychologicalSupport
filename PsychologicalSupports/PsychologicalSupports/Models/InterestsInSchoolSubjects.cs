namespace PsychologicalSupports.Models
{
    public class InterestsInSchoolSubjects
    {
        public int InterestsInSchoolSubjectsID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string Russian { get; set; }
        public string Belorussian { get; set; }
        public string Physics { get; set; }
        public string Story { get; set; }
        public string SocialScientist { get; set; }
        public string Biology { get; set; }
        public string Chemistry { get; set; }
        public string ComputerScience { get; set; }
        public string English { get; set; }
    }
}