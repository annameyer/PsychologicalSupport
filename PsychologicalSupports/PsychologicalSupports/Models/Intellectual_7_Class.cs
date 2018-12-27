namespace PsychologicalSupports.Models
{
    public class Intellectual_7_Class
    {
        public int Intellectual_7_ClassID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public int IQ { get; set; }
        public string Level { get; set; }
        public float AveragePointСommon { get; set; }
        public float AveragePointMath { get; set; }
    }
}