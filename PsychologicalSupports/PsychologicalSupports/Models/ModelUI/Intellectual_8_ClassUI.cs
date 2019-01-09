using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class Intellectual_8_ClassUI
    {
        public long StudentID { get; set; }
        public string InterestMap { get; set; }
        public string RecommendedProfile { get; set; }

        public virtual Student Student { get; set; }
    }
}