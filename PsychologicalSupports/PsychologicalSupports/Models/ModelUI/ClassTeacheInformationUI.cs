using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class ClassTeacheInformationUI
    {
        public long StudentID { get; set; }
        public string Self_harmingBehavior { get; set; }
        public string Isolation { get; set; }
        public string Aggression { get; set; }
        public string AvoidPhysicalContact { get; set; }
        public string AfraidToGoHome { get; set; }
        public string RunningAwayFromHome { get; set; }
        public string WearBodyHidingClothes { get; set; }
        public string DefiantBehavior { get; set; }
        public string LowSelf_esteem { get; set; }
        public string PoorPeerRelations { get; set; }
        public string SharpWeightChange { get; set; }
        public string HystericalEmotionalImbalance { get; set; }
        public string ExceptionallyGoodSexKnowledge { get; set; }

        public virtual Student Student { get; set; }
    }
}