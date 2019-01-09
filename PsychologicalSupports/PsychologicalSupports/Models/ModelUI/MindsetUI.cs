using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class MindsetUI
    {
        public long StudentID { get; set; }
        public string Subject_Effective { get; set; }
        public string AbstractSymbolic { get; set; }
        public string Verbal_Logical { get; set; }
        public string Visually_Shaped { get; set; }
        public string Creativity { get; set; }

        public virtual Student Student { get; set; }
    }
}