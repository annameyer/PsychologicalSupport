namespace PsychologicalSupports.Models
{
    public class Intellectual_8_Class
    {
        public int Intellectual_8_ClassID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string InterestMap { get; set; }
        public string RecommendedProfile { get; set; }

    }
}