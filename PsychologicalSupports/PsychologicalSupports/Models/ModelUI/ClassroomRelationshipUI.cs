using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class ClassroomRelationshipUI
    {
        public long StudentID { get; set; }
        public string IGS_Sishora { get; set; }
        public string Sociometry { get; set; }

        public virtual Student Student { get; set; }
    }
}