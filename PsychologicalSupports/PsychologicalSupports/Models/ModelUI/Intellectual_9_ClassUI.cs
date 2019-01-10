using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class Intellectual_9_ClassUI
    {
        public long StudentID { get; set; }
        public string Profile { get; set; }

        public virtual Student Student { get; set; }
    }
}