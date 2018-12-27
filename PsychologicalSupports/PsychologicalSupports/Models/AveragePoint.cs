namespace PsychologicalSupports.Models
{
    public class AveragePoint
    {
        public int AveragePointID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public float AveragePoint_6 { get; set; }
        public float AveragePoint_7 { get; set; }
        public float AveragePoint_8 { get; set; }
        public float AveragePoint_9 { get; set; }
    }
}