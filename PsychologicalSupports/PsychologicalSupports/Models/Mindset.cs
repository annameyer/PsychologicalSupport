namespace PsychologicalSupports.Models
{
    public class Mindset
    {
        public int MindsetID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string Subject_Effective { get; set; }
        public string AbstractSymbolic { get; set; }
        public string Verbal_Logical { get; set; }
        public string Visually_Shaped { get; set; }
        public string Creativity { get; set; }
    }
}