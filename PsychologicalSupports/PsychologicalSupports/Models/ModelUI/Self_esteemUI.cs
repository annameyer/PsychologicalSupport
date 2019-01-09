

namespace PsychologicalSupports.Models.ModelUI
{
    public class Self_esteemUI
    {
        public long StudentID { get; set; }
        public string Indicator { get; set; }

        public virtual Student Student { get; set; }
    }
}