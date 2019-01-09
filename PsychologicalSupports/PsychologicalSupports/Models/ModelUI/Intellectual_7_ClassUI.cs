using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class Intellectual_7_ClassUI
    {
        public long StudentID { get; set; }
        public Nullable<int> IQ { get; set; }
        public string Level { get; set; }
        public Nullable<double> AveragePointСommon { get; set; }
        public Nullable<double> AveragePointMath { get; set; }

        public virtual Student Student { get; set; }
    }
}