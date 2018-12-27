namespace PsychologicalSupports.Models
{
    public class FamilyAlarmAnalysis
    {
        public int FamilyAlarmAnalysisID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public string Fault { get; set; }
        public string Anxiety { get; set; }
        public string Stress { get; set; }
        public string General { get; set; }
    }
}