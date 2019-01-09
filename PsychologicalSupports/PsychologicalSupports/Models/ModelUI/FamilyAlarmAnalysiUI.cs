using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class FamilyAlarmAnalysiUI
    {
        public long StudentID { get; set; }
        public string Fault { get; set; }
        public string Anxiety { get; set; }
        public string Stress { get; set; }
        public string General { get; set; }

        public virtual Student Student { get; set; }
    }
}