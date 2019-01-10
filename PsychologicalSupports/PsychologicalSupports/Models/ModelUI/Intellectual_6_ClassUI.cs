using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class Intellectual_6_ClassUI
    {
        public long StudentID { get; set; }
        public Nullable<int> TestResult { get; set; }
        public string TestLevel { get; set; }
        public Nullable<double> AveragePoint { get; set; }

        public virtual Student Student { get; set; }
    }
}