using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class PersonalProtagonistAizenkoUI
    {
        public long StudentID { get; set; }
        public string Temperament { get; set; }
        public string Type { get; set; }

        public virtual Student Student { get; set; }
    }
}