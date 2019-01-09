using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class PersonaAnxietyScaleUI
    {
        public long StudentID { get; set; }
        public string School { get; set; }
        public string Interpersonal { get; set; }
        public string Self_assessment { get; set; }
        public string General { get; set; }

        public virtual Student Student { get; set; }
    }
}