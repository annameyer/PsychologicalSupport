namespace PsychologicalSupports.Models
{
    public class PersonalProtagonistAizenko
    {
        public int PersonaAnxietyScaleID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string Temperament { get; set; }
        public string Type { get; set; }
    }
}