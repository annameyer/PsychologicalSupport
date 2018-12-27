namespace PsychologicalSupports.Models
{
    public class PersonaAnxietyScale
    {
        public int PersonaAnxietyScaleID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string School { get; set; }
        public string Interpersonal { get; set; }
        public string Self_assessment { get; set; }
        public string General { get; set; }
    }
}