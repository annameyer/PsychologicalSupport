namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ClassTeacheInformation
    {
        [Key]
        [Column(Order = 0)]
        public long ClassTeacheInformationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Self_harmingBehavior { get; set; }

        [StringLength(50)]
        public string Isolation { get; set; }

        [StringLength(50)]
        public string Aggression { get; set; }

        [StringLength(50)]
        public string AvoidPhysicalContact { get; set; }

        [StringLength(50)]
        public string AfraidToGoHome { get; set; }

        [StringLength(50)]
        public string RunningAwayFromHome { get; set; }

        [StringLength(50)]
        public string WearBodyHidingClothes { get; set; }

        [StringLength(50)]
        public string DefiantBehavior { get; set; }

        [StringLength(50)]
        public string LowSelf_esteem { get; set; }

        [StringLength(50)]
        public string PoorPeerRelations { get; set; }

        [StringLength(50)]
        public string SharpWeightChange { get; set; }

        [StringLength(50)]
        public string HystericalEmotionalImbalance { get; set; }

        [StringLength(50)]
        public string ExceptionallyGoodSexKnowledge { get; set; }

        public virtual Student Student { get; set; }
    }
}
