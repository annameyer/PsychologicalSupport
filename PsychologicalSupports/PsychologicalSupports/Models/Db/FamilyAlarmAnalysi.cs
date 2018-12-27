namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FamilyAlarmAnalysi
    {
        [Key]
        [Column(Order = 0)]
        public long FamilyAlarmAnalysisID { get; set; }

        [Key]
        [Column(Order = 1)]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Fault { get; set; }

        [StringLength(50)]
        public string Anxiety { get; set; }

        [StringLength(50)]
        public string Stress { get; set; }

        [StringLength(50)]
        public string General { get; set; }

        public virtual Student Student { get; set; }
    }
}
