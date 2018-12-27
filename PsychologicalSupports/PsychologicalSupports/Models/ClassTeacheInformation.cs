namespace PsychologicalSupports.Models
{
    public class ClassTeacheInformation
    {
        public int ClassTeacheInformationID { get; set; }
        public int? StudentID { get; set; }
        public Student Student { get; set; }
        public bool Self_harmingBehavior { get; set; }
        public bool Isolation { get; set; }
        public bool Aggression { get; set; }
        public bool AvoidPhysicalContact { get; set; }
        public bool AfraidToGoHome { get; set; }
        public bool RunningAwayFromHome { get; set; }
        public bool WearBodyHidingClothes { get; set; }
        public bool DefiantBehavior { get; set; }
        public bool LowSelf_esteem { get; set; }
        public bool PoorPeerRelations { get; set; }
        public bool SharpWeightChange { get; set; }
        public bool HystericalEmotionalImbalance { get; set; }
        public bool ExceptionallyGoodSexKnowledge { get; set; }
    }
}