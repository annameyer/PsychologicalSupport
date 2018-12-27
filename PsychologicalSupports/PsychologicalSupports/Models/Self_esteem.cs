namespace PsychologicalSupports.Models
{
    public class Self_esteem
    {
        public int Self_esteemID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string Indicator { get; set; }
    }
}