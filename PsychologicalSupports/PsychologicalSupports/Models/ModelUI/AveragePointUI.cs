using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class AveragePointUI
    {
        public long StudentID { get; set; }
        public Nullable<double> AveragePoint_6 { get; set; }
        public Nullable<double> AveragePoint_7 { get; set; }
        public Nullable<double> AveragePoint_8 { get; set; }
        public Nullable<double> AveragePoint_9 { get; set; }

        public virtual Student Student { get; set; }
    }
}