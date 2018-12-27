namespace PsychologicalSupports.Models
{
    public class ClassroomRelationships
    {
        public int ClassroomRelationshipsID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string IGS_Sishora { get; set; }
        public string Sociometry { get; set; }
    }
}