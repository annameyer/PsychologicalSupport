

namespace PsychologicalSupports.Models.ModelUI
{
    public class EmotioTestUI
    {
        public long StudentID { get; set; }
        public string PhysicalAggression { get; set; }
        public string IndirectAggression { get; set; }
        public string Irritability { get; set; }
        public string Negativism { get; set; }
        public string Touchiness { get; set; }
        public string Suspicion { get; set; }
        public string VerbalAggression { get; set; }
        public string Guilt { get; set; }

        public virtual Student Student { get; set; }
    }
}