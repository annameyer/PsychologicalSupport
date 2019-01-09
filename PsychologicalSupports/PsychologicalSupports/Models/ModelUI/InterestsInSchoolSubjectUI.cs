using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class InterestsInSchoolSubjectUI
    {
        public long StudentID { get; set; }
        public string Russian { get; set; }
        public string Belorussian { get; set; }
        public string Physics { get; set; }
        public string Story { get; set; }
        public string SocialScientist { get; set; }
        public string Biology { get; set; }
        public string Chemistry { get; set; }
        public string ComputerScience { get; set; }
        public string English { get; set; }

        public virtual Student Student { get; set; }
    }
}