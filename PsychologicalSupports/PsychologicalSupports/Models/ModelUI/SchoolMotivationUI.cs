using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class SchoolMotivationUI
    {
        public long StudentID { get; set; }
        public string StudyInClass { get; set; }
        public string TestFamilyStudiesLevel { get; set; }
        public string CognitiveInterest { get; set; }
        public string TesMotivationAchievementstLevel { get; set; }
        public string Classmates { get; set; }
        public string Pedagogues { get; set; }
        public string ByParents { get; set; }
        public string FromTheSideOfTheSchool { get; set; }
        public string FromTheSideOfTheFamily { get; set; }
        public string AwarenessOfSocialNecessity { get; set; }
        public string CommunicationMotif { get; set; }
        public string ExtracurricularSchoolMotivation { get; set; }
        public string TheMotiveOfSelf_Realization { get; set; }

        public virtual Student Student { get; set; }
    }
}